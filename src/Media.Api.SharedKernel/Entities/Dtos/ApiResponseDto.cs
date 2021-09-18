using System.Net;

namespace Media.Api.SharedKernel.Entities.Dtos
{
    public class ApiResponseDto : ApiResponseDto<object>
    {
    }

    public class ApiResponseDto<T>
    {
        public string Version { get; init; }

        public int StatusCode { get; init; } = (int)HttpStatusCode.InternalServerError;
        public string ErrorMessage { get; init; }
        public string ToastMessage { get; init; }

        public bool? IsSuccess { get; init; }
        public T Result { get; init; }
    }
}
