using Media.Api.Core.BookAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.List
{
    public class BookListRequest : IRequest<BookListResponse>
    {
        public MediaType? MediaType { get; set; }
    }
}
