using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Middleware.Exceptions
{
    public class ApiExceptionBase : Exception
    {
        public int StatusCode { get; set; }
        public string UserFriendlyMessage { get; set; }

        protected ApiExceptionBase(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ApiExceptionBase(
            int statusCode = (int)HttpStatusCode.BadRequest,
            string message = null,
            string userFriendlyMessage = null,
            Exception innerException = null) : base(message, innerException)
        {
            StatusCode = statusCode;
            UserFriendlyMessage = userFriendlyMessage;
        }
    }
}
