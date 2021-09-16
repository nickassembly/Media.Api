using Media.Api.SharedKernel.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Media.Api.SharedKernel.Middleware
{
    public class ApiResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext?.Request?.Path.Value.Contains("swagger") ?? false)
            {
                await _next(httpContext);
                return;
            }

            string respString = null;
            ApiResponse respObj = new((int)HttpStatusCode.BadRequest) { ErrorMessage = "Something Went Wrong" };

            var orgiginalBody = httpContext.Response.Body;

            try
            {
                using var memoryStream = new MemoryStream();
                httpContext.Response.Body = memoryStream;

                await _next(httpContext);

                memoryStream.Seek(0, SeekOrigin.Begin);

                respString = await new StreamReader(memoryStream).ReadToEndAsync();
                //var objResult = JsonConvert.DeserializeObject(respString);                //Newtonsoft
                //var objResult = JsonSerializer.Deserialize<dynamic>(respString);          //Net Core
                respObj = new ApiResponse(httpContext.Response.StatusCode, respString);
            }
            catch (Exception ex)
            {
                respObj = HandleExceptionAsync(ex);
            }
            finally
            {
                httpContext.Response.Body = orgiginalBody;

                try
                {
                    if (respObj != null)
                    {
                        MemoryStream ApiResponseStream = new();  //  <-- Not Recalculating the Content_Length, so doing this nonsense
                        using var writer = new StreamWriter(ApiResponseStream);
                        //await writer.WriteAsync(JsonConvert.SerializeObject(respObj));  //Newtonsoft
                        await writer.WriteAsync(JsonSerializer.Serialize(respObj));       //Net Core
                        await writer.FlushAsync();

                        httpContext.Response.ContentType = "application/json";
                        httpContext.Response.StatusCode = respObj.StatusCode;
                        httpContext.Response.ContentLength = ApiResponseStream.Length;
                        //httpContext.Response.ContentLength = null;

                        ApiResponseStream.Seek(0, SeekOrigin.Begin);
                        await ApiResponseStream.CopyToAsync(httpContext.Response.Body);
                        //await httpContext.Response.WriteAsync(jsonString);
                    }
                }
                catch (Exception e)
                {
                    //TODO - Log Error - Unable to Wrap Response, Defaulting to Return unwrapped response

                    await httpContext.Response.WriteAsync(respString);
                }
            }
        }

        private static ApiResponse HandleExceptionAsync(Exception exception)
        {

        }

    }
}
