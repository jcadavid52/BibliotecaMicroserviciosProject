using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaReservasLibros.App.BookUseCases.Create;
using SistemaReservasLibros.App.BookUseCases.Delete;
using SistemaReservasLibros.App.BookUseCases.Get;
using SistemaReservasLibros.App.BookUseCases.Update;

namespace SistemaReservasLibros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetBooksQuery query)
        {
            var books = await mediator.Send(query);

            return Ok(books);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand command)
        {
            var id = await mediator.Send(command);
            var uri = $"api/book/{id}";

            return Created(uri,new {id});
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(int id,[FromBody] UpdateBookCommand command)
        {
            command = command with { Id = id };

            var book = await mediator.Send(command);

            return Ok(book);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteMany([FromBody] DeleteBookCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

    }
}
