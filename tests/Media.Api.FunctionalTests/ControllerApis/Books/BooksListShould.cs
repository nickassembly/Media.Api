using Media.Api.SharedKernel.Extensions;
using Media.Api.Web;
using Media.Api.Web.Features.Books.List;
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
            var result = await _client.GetAndDeserializeApiResponseResult<IEnumerable<BookListApiModel>>("api/Books/List");

            var sut = Assert.IsAssignableFrom<IEnumerable<BookListApiModel>>(result);
            Assert.True(sut.Any());
            Assert.Contains(result, i => i.Title == SeedData.Book1.Title);
        }
    }
}
