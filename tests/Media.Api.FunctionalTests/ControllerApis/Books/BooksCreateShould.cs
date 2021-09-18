using Media.Api.Core.AuthorAggregate;
using Media.Api.Core.BookAggregate;
using Media.Api.SharedKernel.Extensions;
using Media.Api.Web;
using Media.Api.Web.Features.Books.Create;
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
    public class BooksCreateShould : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public BooksCreateShould(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnIdOfBookGivenValidBook()
        {
            var book1 = new BookCreateCommand()
            {
                Isbn = "111222333",
                Isbn13 = "22233334444555",
                Authors = new List<Author> { new Author { FirstName = "Stephen", LastName = "King" } },
                Title = "Test 1 Title",
                Publisher = "Sanford and Son",
                // TODO: How to test date times PublishDate, CreatedDate= GetDate(), 
                ListPrice = 29.94m,
                MediaType = MediaType.Audiobook
            };

            var jsonString = JsonConvert.SerializeObject(book1);
            var result = await _client.PostAndDeserializeApiResponseResult<BookCreateResponse>($"api/Books/Create", jsonString);

            Assert.NotEqual(0, result.Id);
            Assert.Equal(book1.Title, result.Title);

        }

    }
}
