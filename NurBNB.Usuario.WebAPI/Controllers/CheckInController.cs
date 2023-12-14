
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.CrearCheckInCommand;
using NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.ModificarCheckInCommand;
using NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearUsuario;
using NurBNB.Usuario.Domain.Model.CheckInOut;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NurBNB.Usuario.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckInController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCheckIn([FromBody] CrearCheckInCommand checkInCommand)
        {
            var checkId = await _mediator.Send(checkInCommand);
            return Ok(checkId);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ModificarCheckInCommand checkInCommand)
        {
            checkInCommand.Id = id;
            return Ok(await _mediator.Send(checkInCommand));
        }
    }
}
