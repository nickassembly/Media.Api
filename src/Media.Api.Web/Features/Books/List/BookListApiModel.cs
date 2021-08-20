using Media.Api.Core.AuthorAggregate;
using Media.Api.Core.BookAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.List
{
    public class BookListApiModel
    {
        public string Isbn { get; private set; }
        public string Isbn13 { get; private set; }
        public List<Author> Authors { get; private set; }
        public string Title { get; private set; }
        public MediaType MediaType { get; private set; }
        public string Publisher { get; private set; }
        public DateTimeOffset PublishDate { get; private set; }
        public decimal ListPrice { get; private set; }
        public Guid CreatedBy { get; private set; }
        public Guid UpdatedBy { get; private set; }
        public DateTimeOffset CreatedDate { get; private set; }
        public DateTimeOffset UpdatedDate { get; private set; }
    }
}
