using Application.Pacientes.Command.Create;
using Application.Pacientes.Command.Set;
using Application.Pacientes.Queries.GetByRutPaciente;
using Application.Pacientes.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PacienteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost()]
        public async Task<ActionResult> CreatePaciente(PacienteCreateCommand request)
        {
            var result = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created, result);
        }
        [HttpPut()]
        public async Task<ActionResult> ModifyPaciente(PacienteSetCommand request)
        {
            var result = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpGet()]
        public async Task<ActionResult> GetPacientes()
        {
            var result = await _mediator.Send(new GetListPacienteQuery());
            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpGet("rut")]
        public async Task<ActionResult> GetByRutPaciente(string rut)
        {
            var result = await _mediator.Send(new GetByRutPacienteQuery() { Rut = rut});
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
