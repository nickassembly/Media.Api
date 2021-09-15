using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.SharedKernel.Entities
{
    public class ApiResponse
    {
        private static readonly List<int> IsSuccessfulCodes = new()
        {
            (int)HttpStatusCode.OK,
            (int)HttpStatusCode.Created,
            (int)HttpStatusCode.NoContent
        };

        private static readonly string Default_SuccessToast = "Operation was successful.";
        private static readonly string Default_FailureToast = "Something unexpected went wrong.";
        private static readonly string Default_UncertainToast = "Unknown response, please try again.";
        private static readonly string Default_FailureError = "Unhandled exception occurred in the API. Returning default ApiResponse object.";

        private object _result;
        private string _contentBody;

        public string Version { get { return "1.0.0"; } } //TODO: API Versioning

        public int StatusCode { get; set; } = (int)HttpStatusCode.InternalServerError;
        public string ErrorMessage { get; set; }
        public string ToastMessage { get; set; }
        public bool? IsSuccess { get; set; }
        public dynamic Result { get => _result; private set => this._result = value; }

        public ApiResponse() { }

        public ApiResponse(int statusCode = (int)HttpStatusCode.InternalServerError, string contentBody = null)
        {
            this.StatusCode = statusCode;
            this._contentBody = contentBody;
            this.SetResultObject(contentBody);

            if (!this.IsSuccess.HasValue)
            {
                this.ToastMessage ??= Default_UncertainToast;
            }
            else
            {
                if (string.IsNullOrEmpty(this.ToastMessage))
                    this.ToastMessage = (this.IsSuccess.Value) ? Default_SuccessToast : (this.ErrorMessage ?? Default_FailureToast);
                if (string.IsNullOrEmpty(this.ErrorMessage))
                    this.ErrorMessage = (this.IsSuccess.Value) ? "" : Default_FailureError;
            }
        }

        private void SetResultObject(string resultJson)
        {
            if (string.IsNullOrEmpty(resultJson))
                return;

            if (this.StatusCode == 0)
                throw new System.Exception("StatusCode must be set to a valid value before ApiResponse.SetResultObject can be executed.");

            this.IsSuccess = IsSuccessfulCodes.Contains(this.StatusCode);

            if (!resultJson.StartsWith("["))
            {

            }
        }

    }
}
