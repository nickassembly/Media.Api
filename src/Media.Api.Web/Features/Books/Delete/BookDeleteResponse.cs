using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.Delete
{
    public class BookDeleteResponse : IRequest<BookDeleteResponse>
    {
        public int Id { get; set; }
        public bool IsSuccess { get; set; }
        public string ToastMessage { get; set; }
        public string ErrorMessage { get; set; }

    }
}
