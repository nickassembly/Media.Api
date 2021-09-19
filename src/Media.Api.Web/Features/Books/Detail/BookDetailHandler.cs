using AutoMapper;
using Media.Api.Core.BookAggregate;
using Media.Api.SharedKernel.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.GetById
{
    public class BookDetailHandler : IRequestHandler<BookDetailRequest, BookDetailResponse>
    {
        private readonly IRepository<Book> _repo;
        private readonly IMapper _mapper;

        public BookDetailHandler(IRepository<Book> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BookDetailResponse> Handle(BookDetailRequest request, CancellationToken cancellationToken)
        {
           // BookDetailResponse response = new();

            var book = await _repo.GetByIdAsync(request.Id, cancellationToken);

            return _mapper.Map<BookDetailResponse>(book);
        }
    }
}
