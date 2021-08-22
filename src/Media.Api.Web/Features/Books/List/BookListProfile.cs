using AutoMapper;
using Media.Api.Core.BookAggregate;

namespace Media.Api.Web.Features.Books.List
{
    public class BookListProfile : Profile
    {
        public BookListProfile()
        {
            CreateMap<Book, BookListApiModel>();
        }
    }
}
