using System.Collections.Generic;

namespace Media.Api.Web.Features.Books.List
{
    public class BookListResponse
    {
        public IEnumerable<BookListApiModel> Books { get; set; }
    }
}
