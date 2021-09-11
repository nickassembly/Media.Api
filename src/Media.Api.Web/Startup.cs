using System;
using System.Collections.Generic;
using Ardalis.ListStartupServices;
using Autofac;
using Media.Api.Core;
using Media.Api.Infrastructure;
using Media.Api.Web.Middleware;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Media.Api.Web
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            Configuration = config;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddAutoMapper(typeof(Startup).Assembly);

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            string connectionString = Configuration.GetConnectionString("DefaultConnection");  //Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext(connectionString);

            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddRazorPages();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.EnableAnnotations();
            });

            // add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
            services.Configure<ServiceConfig>(config =>
            {
                config.Services = new List<ServiceDescriptor>(services);

                // optional - default path to view services is /listallservices - recommended to choose your own path
                config.Path = "/listservices";
            });

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DefaultInfrastructureModule(_env.EnvironmentName == "Development"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
                app.UseShowAllServicesMiddleware();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Experimenting with Middleware in this section (extension method calls below)
            // Use will pass the request to the next, which must be passed in as a parameter
            app.Use(async (context, next) =>
            {
                Console.WriteLine("Middleware 1 Started");
                await context.Response.WriteAsync("This is the first middleware 1");
                await next();
                Console.WriteLine("Middleware 1 Ended");
            });

            app.Use(async (context, next) =>
            {
                Console.WriteLine("\nMiddleware 2 Started");
                await context.Response.WriteAsync("\nThis is the second middleware 2");
                await next();
                Console.WriteLine("Middleware 2 Ended");
            });

            // Run is a terminal delegate, does NOT pass the request to the Next delegate
            app.Run(async c => await c.Response.WriteAsync("\nWelcome to terminal middleware"));

            //app.UseFirstMiddleware();
            //app.UseSecondMiddleware();
            //app.UseLastMiddleware();

            app.UseRouting();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
