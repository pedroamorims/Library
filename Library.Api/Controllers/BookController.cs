using Library.Application.Commands.CreateBook;
using Library.Application.Queries.GetAllBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllBooksQuery = new GetAllBooksQuery();
            var books = await _mediator.Send(getAllBooksQuery);

            return Ok(books);
        }

    }
}
