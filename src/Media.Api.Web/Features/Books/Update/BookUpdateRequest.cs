using Media.Api.Core.AuthorAggregate;
using Media.Api.Core.BookAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.Update
{
    public class BookUpdateRequest : IRequest<BookUpdateResponse>
    {
        public BookUpdateCommand BookUpdateCommand { get; set; }
    }
}
