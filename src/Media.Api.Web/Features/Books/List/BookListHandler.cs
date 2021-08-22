using AutoMapper;
using Media.Api.Core.BookAggregate;
using Media.Api.Core.BookAggregate.Specifications;
using Media.Api.SharedKernel.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.List
{
    public class BookListHandler : IRequestHandler<BookListRequest, BookListResponse>
    {
        private readonly IRepository<Book> _repo;
        private readonly IMapper _mapper;

        public BookListHandler(IRepository<Book> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BookListResponse> Handle(BookListRequest request, CancellationToken cancellationToken)
        {
            BookListResponse response = new();
            var books = new List<Book>();

            if (request.MediaType == null)
                books = await _repo.ListAsync(cancellationToken);
            else
            {
                ListByMediaTypeSpec spec = new(request.MediaType);
                books = await _repo.ListAsync(spec, cancellationToken);

                if (!books.Any())
                    return response;
            }

            response.Books = _mapper.Map<IEnumerable<BookListApiModel>>(books);

            return response;
        }
    }
}
