using AutoMapper;
using Media.Api.Core.BookAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.Delete
{
    public class BookDeleteProfile : Profile
    {
        public BookDeleteProfile()
        {
            CreateMap<BookDeleteCommand, Book>();
            CreateMap<Book, BookDeleteResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(o => o));
        }
    }
}
