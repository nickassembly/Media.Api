using Media.Api.Web;
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

        [Fact]
        public async Task ReturnsNextBookIdGivenBookUpdate()
        {

        }
    }
}
