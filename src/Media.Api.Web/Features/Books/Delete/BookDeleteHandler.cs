using AutoMapper;
using Media.Api.Core.BookAggregate;
using Media.Api.Core.Exceptions;
using Media.Api.SharedKernel.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.Delete
{
    public class BookDeleteHandler : IRequestHandler<BookDeleteRequest, BookDeleteResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Book> _repo;

        public BookDeleteHandler(IRepository<Book> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BookDeleteResponse> Handle(BookDeleteRequest request, CancellationToken cancellationToken)
        {
            var response = new BookDeleteResponse() { Id = request.BookDeleteCommand.Id };

            try
            {
                var deletedBook = await _repo.GetByIdAsync(request.BookDeleteCommand.Id, cancellationToken);

                await _repo.DeleteAsync(deletedBook);

                response.IsSuccess = true;
            }
            catch (GuardBaseException e)
            {
                response.ErrorMessage = e.Message;
            }

            await _repo.SaveChangesAsync(cancellationToken);

            return response;

        }
    }
}
