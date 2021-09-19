using Media.Api.SharedKernel.Extensions;
using Media.Api.Web;
using Media.Api.Web.Features.Books.GetById;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Media.Api.FunctionalTests.ControllerApis.Books
{
    [Collection("Sequential")]
    public class BookDetailShould : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly HttpClient _client;

        public BookDetailShould(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnBookGivenValidId()
        {
            int Id = 1;
            var result = await _client.GetAndDeserializeApiResponseResult<BookDetailApiModel>($"/api/Books/Detail/{Id}");

            Assert.Equal(1, result.Id);
            Assert.Equal(SeedData.Book1.Title, result.Title); 
        }
    }
}
