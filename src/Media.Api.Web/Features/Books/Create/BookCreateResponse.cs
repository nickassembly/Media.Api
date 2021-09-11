using Media.Api.Core.BookAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.Create
{
    public class BookCreateResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //public bool IsSuccess { get; set; }
        //public string ToastMessage { get; set; }
        //public string ErrorMessage { get; set; }
    }
}
