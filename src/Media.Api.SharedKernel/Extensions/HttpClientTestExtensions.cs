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
        // TODO: Add the rest of these classes for this extension class and test


        public static async Task<T> PostAndDeserializeApiResponseResult<T>(this HttpClient _client, string url, string jsonString)
        {
            var content = new StringContent(jsonString.ToString(), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, content);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponseDto<T>>(stringResponse);

            return (result == default) ? default : result.Result;
        }
    }
}
