using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Middleware
{
    public static class ApplicationBuilderExtension
    {
        public static void UseFirstMiddleware(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("First Middleware Test ");
                await next();
            });
        }

        public static void UseSecondMiddleware(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Second Middleware Test ");
                await next();
            });
        }

        public static void UseLastMiddleware(this IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Last Middleware Test");
            });
        }
    }
}
