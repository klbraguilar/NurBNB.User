using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearGuests;
using NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearUsuario;

namespace NurBNB.Usuario.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GuestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuest([FromBody] CrearHuespedCommand huespedCommand)
        {
            CrearUsuarioCommand usuario = new CrearUsuarioCommand();
            usuario.UserName = huespedCommand.user.UserName;
            usuario.Password= huespedCommand.user.Password;
            usuario.Email= huespedCommand.user.Email;
            var userId = await _mediator.Send(usuario);
            huespedCommand.usuarioId = userId;
            var guestID = await _mediator.Send(huespedCommand);
            return Ok(guestID);
        }
    }
}
