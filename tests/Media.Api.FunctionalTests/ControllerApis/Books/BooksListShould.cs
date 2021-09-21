using Media.Api.Web;
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
    public class BooksListShould : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly HttpClient _client;

        public BooksListShould(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnBookCollection()
        {

        }
    }
}
