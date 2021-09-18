using System;
using System.Net;
using System.Runtime.Serialization;

namespace Media.Api.SharedKernel.Entities.Exceptions
{
    [Serializable()]
    public class ApiResponseExceptionBase : ApplicationException
    {
        public HttpStatusCode StatusCode { get; set; }
        public string UserFriendlyMessage { get; set; }

        protected ApiResponseExceptionBase(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ApiResponseExceptionBase(HttpStatusCode statusCode = HttpStatusCode.BadRequest, string message = null, string userFriendlyMessage = null, Exception innerException = null) : base(message, innerException)
        {
            StatusCode = statusCode;
            UserFriendlyMessage = userFriendlyMessage;
        }
    }
}
