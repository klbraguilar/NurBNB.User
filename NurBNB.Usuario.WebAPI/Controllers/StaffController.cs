using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearEncargados;
using NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearUsuario;

namespace NurBNB.Usuario.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StaffController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff([FromBody] CrearStaffCommand staffCommand)
        {
            CrearUsuarioCommand usuario = new CrearUsuarioCommand();
            usuario.UserName = staffCommand.user.UserName;
            usuario.Password = staffCommand.user.Password;
            usuario.Email = staffCommand.user.Email;
            var userId = await _mediator.Send(usuario);
            staffCommand.usuarioId = userId;
            var staffID = await _mediator.Send(staffCommand);
            return Ok(staffID);
        }
    }
}
