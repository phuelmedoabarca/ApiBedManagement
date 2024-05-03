using Application.Ingresos.Command.Create;
using Application.Ingresos.Command.Set;
using Application.Ingresos.Queries.GetByIdIngreso;
using Application.Ingresos.Queries.GetList;
using Application.Pacientes.Queries.GetByRutPaciente;
using Application.Pacientes.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngresoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IngresoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost()]
        public async Task<ActionResult> CreateIngreso(IngresoCreateCommand request)
        {
            var result = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created, result);
        }
        [HttpPut()]
        public async Task<ActionResult> ModifyIngreso(IngresoSetCommand request)
        {
            var result = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpGet("idEstado")]
        public async Task<ActionResult> GetIngresos(int idEstado)
        {
            var result = await _mediator.Send(new GetListIngresoQuery() { IdEstado = idEstado });
            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpGet("idIngreso")]
        public async Task<ActionResult> GetByIdIngreso(Guid idIngreso)
        {
            var result = await _mediator.Send(new GetByIdIngresoQuery() { IdIngreso = idIngreso });
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
