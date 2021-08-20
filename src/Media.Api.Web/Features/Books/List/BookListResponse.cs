using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.List
{
    public class BookListResponse
    {
        public IEnumerable<BookListApiModel> Books { get; set; }
    }
}
