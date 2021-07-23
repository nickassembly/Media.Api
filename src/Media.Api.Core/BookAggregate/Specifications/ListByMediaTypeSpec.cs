using Ardalis.Specification;
using System.Linq;

namespace Media.Api.Core.BookAggregate.Specifications
{
    public class ListByMediaTypeSpec : Specification<Book>
    {
        public ListByMediaTypeSpec(MediaType? mediaType)
        {
            Query.Where(book => book.MediaType == mediaType);
        }
    }
}
