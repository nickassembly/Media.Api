using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
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
                try
                {
                    dynamic rspBody = JsonSerializer.Deserialize<ExpandoObject>(resultJson);

                    if (!IsPropertyExist(rspBody, "IsSuccess"))
                    {
                        if (IsPropertyExist(rspBody, "isSuccess"))
                            this.IsSuccess = AsBool(rspBody.IsSuccess);
                    }
                    else
                    {
                        this.IsSuccess = AsBool(rspBody.IsSuccess);
                    }

                    if (!IsPropertyExist(rspBody, "ToastMessage"))
                    {
                        if (IsPropertyExist(rspBody, "toastMessage"))
                            this.ToastMessage = AsString(rspBody.ToastMessage);
                    }
                    else
                    {
                        this.ToastMessage = AsString(rspBody.ToastMessage);
                    }

                    if (!IsPropertyExist(rspBody, "ErrorMessage"))
                    {
                        if (IsPropertyExist(rspBody, "ErrorMessage"))
                            this.ErrorMessage = AsString(rspBody.ErrorMessage);
                    }
                    else
                    {
                        this.ErrorMessage = AsString(rspBody.ErrorMessage);
                    }

                    this._result = rspBody;
                    return;
                }
                catch (Exception)
                {
                  // Follow into Next block
                }
            }

            try
            {
                this._result = JsonSerializer.Deserialize<dynamic>(resultJson);

                return;
            }
            catch (Exception)
            {

                this.ToastMessage = resultJson;

                return;
            }
        }

        private static bool IsPropertyExist(dynamic settings, string name)
        {
            if (settings is ExpandoObject)
                return ((IDictionary<string, object>)settings).ContainsKey(name);

            return settings.GetType().GetProperty(name) != null;
            
        }

        private static string AsString(dynamic value)
        {
            if (value is string)
                return value;
            else
                return value?.GetString();
        }

        private static bool AsBool(dynamic value)
        {
            if (value is bool)
                return value;
            else
                return value?.GetBoolean() ?? false;
        }

        private static int AsInt(dynamic value)
        {
            if (value is int)
                return value;
            else
                return value?.GetInt32() ?? 0;
        }
    }
}
