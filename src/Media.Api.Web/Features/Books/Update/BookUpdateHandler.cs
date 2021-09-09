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

namespace Media.Api.Web.Features.Books.Update
{
    public class BookUpdateHandler : IRequestHandler<BookUpdateRequest, BookUpdateResponse>
    {
        private readonly IRepository<Book> _repo;
        private readonly IMapper _mapper;

        public BookUpdateHandler(IRepository<Book> repo, IMapper mapper = null)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BookUpdateResponse> Handle(BookUpdateRequest request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request.BookUpdateCommand);

            await _repo.UpdateAsync(book, cancellationToken);

            return _mapper.Map<BookUpdateResponse>(new Book() { Id = book.Id });
        }
    }
}
