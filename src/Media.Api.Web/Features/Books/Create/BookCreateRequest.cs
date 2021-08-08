using Media.Api.Core.AuthorAggregate;
using Media.Api.Core.BookAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.Create
{
    public class BookCreateRequest : IRequest<BookCreateResponse>
    {
        public string Isbn { get; set; }
        public string Isbn13 { get; set; }
        public List<Author> Authors { get; set; }
        public string Title { get; set; }
        public MediaType MediaType { get; set; }
        public string Publisher { get; set; }
        public DateTimeOffset PublishDate { get; set; }
        public decimal ListPrice { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
