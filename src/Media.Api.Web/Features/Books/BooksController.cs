using Media.Api.Web.Features.Books.Create;
using Media.Api.Web.Features.Books.GetById;
using Media.Api.Web.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books
{
    public class BooksController : BaseApiController
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // TODO: Test Post and Get by Id

        // POST: api/Books/
        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a book",
            Description = "Add a new book",
            OperationId = "Books.Create",
            Tags = new[] { "Books" })]
        public async Task<IActionResult> Create([FromBody] BookCreateRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response.Id);
        }

        // GET: api/Books/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a book by id",
            Description = "Get the details of a book",
            OperationId = "Books.GetById",
            Tags = new[] {"Books "})]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new BookGetByIdRequest { Id = id });

            return response.BookResult == null ? NotFound() : Ok(response.BookResult);
        }


    }
}
