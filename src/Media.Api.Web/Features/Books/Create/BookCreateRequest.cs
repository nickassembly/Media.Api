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
        public BookCreateCommand BookCreateCommand { get; set; }
    }
}
