using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.Delete
{
    public class BookDeleteRequest : IRequest<BookDeleteResponse>
    {
        public int Id { get; set; }
    }
}
