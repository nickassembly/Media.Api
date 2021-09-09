using AutoMapper;
using Media.Api.Core.BookAggregate;

namespace Media.Api.Web.Features.Books.Update
{
    public class BookUpdateProfile : Profile
    {
        public BookUpdateProfile()
        {
            CreateMap<BookUpdateCommand, Book>();
            CreateMap<Book, BookUpdateResponse>();

        }
    }
}
