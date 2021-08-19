using AutoMapper;
using Media.Api.Core.BookAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.GetById
{
    public class BookGetByIdProfile : Profile
    {
        public BookGetByIdProfile()
        {
            CreateMap<Book, BookGetByIdApiModel>();
        }
    }
}
