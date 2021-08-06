using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Middleware
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
        public object Result { get; set; }

        public ApiResponse(int statusCode, object result = null, string errorMessage = null)
        {
            StatusCode = statusCode;
            Result = result;
            ErrorMessage = errorMessage;
        }
    }
}
