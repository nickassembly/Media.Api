using Media.Api.Core.BookAggregate;
using Media.Api.SharedKernel.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.Delete
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookRequest, DeleteBookResponse>
    {
        private readonly IRepository<Book> _repo;

        public async Task<DeleteBookResponse> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteBookResponse() { Id = request.Id };

            var bookToBeDeleted = await _repo.GetByIdAsync(request.Id, cancellationToken);

            if (bookToBeDeleted == null)
                return response;

            await _repo.DeleteAsync(bookToBeDeleted, cancellationToken);

            response.IsSuccess = true;

            return response;
        }
    }
}
