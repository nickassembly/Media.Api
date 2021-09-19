using Media.Api.Core.BookAggregate;
using Media.Api.SharedKernel.Interfaces;
using Media.Api.Web.Features.Books.Create;
using Media.Api.Web.Features.Books.Delete;
using Media.Api.Web.Features.Books.GetById;
using Media.Api.Web.Features.Books.List;
using Media.Api.Web.Features.Books.Update;
using Media.Api.Web.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Media.Api.Web.Features.Books
{
    [Route("api/[controller]/[action]")]
    public class BooksController : BaseApiController
    {
        private readonly IRepository<Book> _repository;
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator, IRepository<Book> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        // GET: api/Books/
        [HttpGet]
        [SwaggerOperation(
            Summary = "List books",
            Description = "Get a list of books",
            OperationId = "Books.List",
            Tags = new[] {"Books"})]
        public async Task<IActionResult> List()
        {
            var response = await _mediator.Send(new BookListRequest() { MediaType = null });

            return response.Books == null ? NotFound() : Ok(response.Books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await _mediator.Send(new BookDetailRequest() { Id = id });

            return (result != null) ? Ok(result.BookResult) : NotFound($"Searched Id of {id}");
        }

        // GET: api/Books/{id}
        //[HttpGet("{id}")]
        //[SwaggerOperation(
        //    Summary = "Get a book by id",
        //    Description = "Get the details of a book",
        //    OperationId = "Books.GetById")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var response = await _mediator.Send(new BookGetByIdRequest { Id = id });

        //    return response.BookResult == null ? NotFound() : Ok(response.BookResult);
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCreateCommand book)
        {
            var result = await _mediator.Send(new BookCreateRequest() { BookCreateCommand = book });

            return Ok(result);
        }

        // PUT: api/Books/
        [HttpPut]
        [SwaggerOperation(
            Summary = "Updates an fields in existing book",
            Description = "Update an a book",
            OperationId = "Books.Update")]
        public async Task<IActionResult> Update([FromBody] BookUpdateRequest request)
        {
            var response = await _mediator.Send(request);

            return response.StatusCode == "NotFound" ? NotFound(response.Id) : Ok(response.Id);
        }

       

        // DELETE: api/Books/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(
          Summary = "Delete a book",
            Description = "Remove a book",
            OperationId = "Books.Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new BookDeleteRequest() { Id = id });

            return !response.IsSuccess ? NotFound() : Ok(response.Id);
        }



    }
}
