using Media.Api.SharedKernel.Entities.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.SharedKernel.Extensions
{
    public static class HttpClientTestExtensions
    {
        public static async Task<ApiResponseDto<T>> GetAndDeserializeApiResponseDto<T>(this HttpClient _client, string url)
        {
            var response = await _client.GetAsync(url);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponseDto<T>>(stringResponse);

            return result;
        }

        public static async Task<T> GetAndDeserializeApiResponseResult<T>(this HttpClient _client, string url)
        {
            var response = await _client.GetAsync(url);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponseDto<T>>(stringResponse);

            return (result == default) ? default : result.Result;
        }

        public static async Task<T> PutAndDeserializeApiResponseResult<T>(this HttpClient _client, string url, string jsonString)
        {
            var content = new StringContent(jsonString.ToString(), Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(url, content);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponseDto<T>>(stringResponse);

            return (result == default) ? default : result.Result;
        }

        public static async Task<T> PostAndDeserializeApiResponseResult<T>(this HttpClient _client, string url, string jsonString)
        {
            var content = new StringContent(jsonString.ToString(), Encoding.UTF8, "application/json");

            // TODO: Issue is this call does not go to => ApiResponse.cs as it should

            HttpResponseMessage response = await _client.PostAsync(url, content);

            string stringResponse = await response.Content.ReadAsStringAsync();
            ApiResponseDto<T> result = JsonConvert.DeserializeObject<ApiResponseDto<T>>(stringResponse);

            return (result == default) ? default : result.Result;
        }
    }
}
