using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.CrearCheckInCommand;
using NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.CrearCheckOutCommand;
using NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.ModificarCheckInCommand;
using NurBNB.Usuario.Appplication.UseCases.CheckInOut.Command.ModificarCheckOutCommand;

namespace NurBNB.Usuario.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckOutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCheckOut([FromBody] CrearCheckOutCommand checkOutCommand)
        {
            var checkId = await _mediator.Send(checkOutCommand);
            return Ok(checkId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ModificarCheckOutCommand checkOutCommand)
        {
            checkOutCommand.Id = id;
            return Ok(await _mediator.Send(checkOutCommand));
        }
    }
}
