using AutoMapper;
using Media.Api.Core.BookAggregate;
using Media.Api.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books.GetById
{
    public class BookGetByIdHandler : IRequestHandler<BookGetByIdRequest, BookGetByIdResponse>
    {
        private readonly IRepository<Book> _repo;
        private readonly IMapper _mapper;

        public BookGetByIdHandler(IRepository<Book> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


    }
}
