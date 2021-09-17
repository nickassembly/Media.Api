using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.SharedKernel.Middleware
{
    public static class ResponseMiddlewareExtension
    {
        public static void ConfigureCustomResponseMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiResponseMiddleware>();
        }
    }
}
