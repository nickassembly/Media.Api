using Media.Api.Core.BookAggregate;
using Media.Api.SharedKernel.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.Delete
{
    public class BookDeleteHandler : IRequestHandler<BookDeleteRequest, BookDeleteResponse>
    {
        private readonly IRepository<Book> _repo;

        public BookDeleteHandler(IRepository<Book> repo)
        {
            _repo = repo;
        }

        public async Task<BookDeleteResponse> Handle(BookDeleteRequest request, CancellationToken cancellationToken)
        {
            var response = new BookDeleteResponse() { Id = request.Id };

            var bookToBeDeleted = await _repo.GetByIdAsync(request.Id, cancellationToken);

            if (bookToBeDeleted == null)
                return response;

            await _repo.DeleteAsync(bookToBeDeleted, cancellationToken);

            response.IsSuccess = true;

            return response;
        }
    }
}
