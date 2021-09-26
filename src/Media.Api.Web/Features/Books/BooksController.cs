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

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new BookListRequest());

            return Ok(result.Books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await _mediator.Send(new BookDetailRequest() { Id = id });

            return (result != null) ? Ok(result.BookResult) : NotFound($"Searched Id of {id}");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCreateCommand book)
        {
            var result = await _mediator.Send(new BookCreateRequest() { BookCreateCommand = book });

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BookUpdateCommand book)
        {
            var result = await _mediator.Send(new BookUpdateRequest() { BookUpdateCommand = book });

            return Ok(result);
        }

        [HttpPost] 
        public async Task<IActionResult> Delete([FromBody] BookDeleteCommand book)
        {
            var result = await _mediator.Send(new BookDeleteRequest() { BookDeleteCommand = book });

            return Ok(result);
        }

        // DELETE: api/Books/{id}
        //[HttpDelete("{id}")]
        //[SwaggerOperation(
        //  Summary = "Delete a book",
        //    Description = "Remove a book",
        //    OperationId = "Books.Delete")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var response = await _mediator.Send(new BookDeleteRequest() { Id = id });

        //    return !response.IsSuccess ? NotFound() : Ok(response.Id);
        //}



    }
}
