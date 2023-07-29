using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NurBNB.Usuario.Appplication.UseCases.Usuario.Command.CrearUsuario;

namespace NurBNB.Usuario.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CrearUsuarioCommand usuarioCommand)
        {
            var itemId = await _mediator.Send(usuarioCommand);
            return Ok(itemId);
        }
    }
}
