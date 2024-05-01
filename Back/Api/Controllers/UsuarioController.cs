using Application.Pacientes.Queries.GetByRutPaciente;
using Application.Pacientes.Queries.GetList;
using Application.Usuarios.Command.Create;
using Application.Usuarios.Command.Set;
using Application.Usuarios.Queries.GetByRutUsuario;
using Application.Usuarios.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost()]
        public async Task<ActionResult> CreateUsuario(UsuarioCreateCommand request)
        {
            var result = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created, result);
        }
        [HttpPut()]
        public async Task<ActionResult> ModifyUsuario(UsuarioSetCommand request)
        {
            var result = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpGet()]
        public async Task<ActionResult> GetUsuarios()
        {
            var result = await _mediator.Send(new GetListUsuarioQuery());
            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpGet("rut")]
        public async Task<ActionResult> GetByRutUsuario(string rut)
        {
            var result = await _mediator.Send(new GetByRutUsuarioQuery() { Rut = rut });
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
