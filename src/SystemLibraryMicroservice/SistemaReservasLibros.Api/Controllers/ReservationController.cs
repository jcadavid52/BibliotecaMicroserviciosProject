using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaReservasLibros.App.ReservationUseCases.Create;

namespace SistemaReservasLibros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> Create([FromBody] CreateReservationCommand command)
        {
            var id = await mediator.Send(command);

            return Created("",new {id});
        }
    }
}
