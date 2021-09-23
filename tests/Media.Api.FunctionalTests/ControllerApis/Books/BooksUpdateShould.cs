using Media.Api.SharedKernel.Extensions;
using Media.Api.Web;
using Media.Api.Web.Features.Books.Update;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Media.Api.FunctionalTests.ControllerApis.Books
{
    [Collection("Sequential")]
    public class BooksUpdateShould : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly HttpClient _client;

        public BooksUpdateShould(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        // TODO: Test Update 
        [Fact]
        public async Task ReturnsNextBookIdGivenBookUpdate()
        {
            var Book1 = new BookUpdateCommand()
            {
                Id = 3,
                Title = "Jurassic Park",
                Isbn = "97811122233"
            };

            var jsonString = JsonConvert.SerializeObject(Book1);
            var result = await _client.PutAndDeserializeApiResponseResult<BookUpdateResponse>($"api/Books/Update", jsonString);

            Assert.NotEqual(0, result.Id);
            Assert.Equal(Book1.Id, result.Id);
        }
    }
}
