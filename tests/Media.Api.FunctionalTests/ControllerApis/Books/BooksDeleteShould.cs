using Media.Api.Web;
using Media.Api.Web.Features.Books.Delete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Media.Api.FunctionalTests.ControllerApis.Books
{
    [Collection("Sequential")]
    public class BooksDeleteShould : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly HttpClient _client;

        public BooksDeleteShould(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task DeleteBook()
        {
            var Book1 = new BookDeleteCommand()
            {
                Id = 2
            };

            var jsonString = JsonConvert.SerializeObject(Book1);
            var bookContent = new StringContent(jsonString.ToString(), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/Books/Delete", bookContent);

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BookDeleteResponse>(stringResponse);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task ThrowExceptionWhenDeleteFails()
        {
            var Book1 = new BookDeleteCommand()
            {
            };

            var jsonString = JsonConvert.SerializeObject(Book1);
            var bookContent = new StringContent(jsonString.ToString(), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/Books/Delete", bookContent);

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BookDeleteResponse>(stringResponse);

            Assert.False(result.IsSuccess);
        }


    }
}
