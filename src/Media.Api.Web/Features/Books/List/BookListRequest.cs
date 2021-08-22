using Media.Api.Core.BookAggregate;
using MediatR;

namespace Media.Api.Web.Features.Books.List
{
    public class BookListRequest : IRequest<BookListResponse>
    {
        public MediaType? MediaType { get; set; }
    }
}
