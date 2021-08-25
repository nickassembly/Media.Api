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
            BookUpdateResponse response = new() { Id = request.Id, StatusCode = "NotFound" };

            var bookToEdit = await _repo.GetByIdAsync(request.Id, cancellationToken);

            if (bookToEdit == null) return response;

            _mapper.Map(request, bookToEdit);

            await _repo.SaveChangesAsync(cancellationToken);
            
            response.StatusCode = "Updated";

            return response;
        }
    }
}
