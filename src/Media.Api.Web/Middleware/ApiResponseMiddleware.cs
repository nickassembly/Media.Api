using Media.Api.Web.Middleware.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Media.Api.Web.Middleware
{
    // TODO: May be able to remove middleware from Web project if it is in the shared kernal
    public class ApiResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            ApiResponse respObj = new((int)HttpStatusCode.BadRequest) { ErrorMessage = "Something Went Wrong" };

            var orgiginalBody = httpContext.Response.Body;
            var status = httpContext.Response.StatusCode;

            try
            {
                using var memoryStream = new MemoryStream();
                httpContext.Response.Body = memoryStream;

                await _next(httpContext);

                memoryStream.Seek(0, SeekOrigin.Begin);

                var readToEnd = new StreamReader(memoryStream).ReadToEnd();
                var objResult = readToEnd.Contains("Version") ? readToEnd : JsonConvert.DeserializeObject(readToEnd);
                var statusCode = httpContext.Response.StatusCode;
                var errorMessage = statusCode == (int)HttpStatusCode.OK ? null : "Query returned no results";
                bool isSuccess = statusCode == (int)HttpStatusCode.OK;

                respObj.StatusCode = statusCode;
                respObj.ErrorMessage = errorMessage;
                respObj.IsSuccess = isSuccess;
                respObj.Result = objResult;
            }
            catch (Exception ex)
            {
                respObj = HandleExceptionAsync(ex);
            }
            finally
            {
                httpContext.Response.Body = orgiginalBody;

                if (respObj != null)
                {
                    httpContext.Response.ContentType = "application/json";
                    httpContext.Response.StatusCode = (int)respObj.StatusCode;
                    httpContext.Response.Headers.ContentLength = null;
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(respObj));
                }
            }
        }

        private static ApiResponse HandleExceptionAsync(Exception exception)
        {
            ApiResponse respObj = new((int)HttpStatusCode.BadRequest, null, "Something Went Wrong") { IsSuccess = false };

            try
            {
                Log.Error($"Error creating the ApiResponse object: {exception?.ToString()}");
            }
            catch (Exception)
            {
            }

            try
            {
                if (exception is ApiExceptionBase)
                {
                    var apiException = exception as ApiExceptionBase;

                    respObj.StatusCode = (int)apiException.StatusCode;
                    respObj.ErrorMessage = apiException.UserFriendlyMessage;
                }
                else if (exception is ValidationException)
                {
                    respObj.ErrorMessage = "An API Validation Error Occurred";
                }
                else if (exception is InvalidOperationException)
                {
                    respObj.ErrorMessage = exception.Message;
                }
                else if (exception is DbUpdateException)
                {
                    var exp = exception as DbUpdateException;

                    respObj.ErrorMessage = "An Error Occurred When Attempting to Update the Database";
                }
                else
                {
                    respObj.StatusCode = (int)HttpStatusCode.InternalServerError;
                    respObj.ErrorMessage = exception?.Message ?? "Something unexpected happened without passing a message";
                }
            }
            catch (Exception)
            {
                respObj.ErrorMessage = $"{respObj.ErrorMessage}  - *Error May Misleading, Additional Error Occurred Handling Exception";
            }

            return respObj;
        }

    }

}

