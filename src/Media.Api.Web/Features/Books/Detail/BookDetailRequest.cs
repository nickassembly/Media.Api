using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.GetById
{
    public class BookDetailRequest : IRequest<BookDetailResponse>
    {
        public int Id { get; set; }
    }
}
