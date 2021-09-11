using AutoMapper;
using Media.Api.Core.BookAggregate;
using Media.Api.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.Create
{
    public class BookCreateHandler : IRequestHandler<BookCreateRequest, BookCreateResponse>
    {
        private readonly IRepository<Book> _repo;
        private readonly IMapper _mapper;

        public BookCreateHandler(IRepository<Book> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BookCreateResponse> Handle(
            BookCreateRequest request,
            CancellationToken cancellationToken)
        {

            var newBook = _mapper.Map<Book>(request.BookCreateCommand);

            var createdNewBook = await _repo.AddAsync(newBook, cancellationToken);

            return _mapper.Map<BookCreateResponse>(createdNewBook);

        }
    }
}
