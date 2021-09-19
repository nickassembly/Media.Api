using AutoMapper;
using Media.Api.Core.BookAggregate;

namespace Media.Api.Web.Features.Books.GetById
{
    public class BookDetailProfile : Profile
    {
        public BookDetailProfile()
        {
            CreateMap<Book, BookDetailApiModel>();
            // TODO: Research Automapper....Not sure exactly what is going on with the line below...but it is necessary
            CreateMap<Book, BookDetailResponse>()
                .ForMember(dest => dest.BookResult, opt => opt.MapFrom(o => o));
        }
    }
}
