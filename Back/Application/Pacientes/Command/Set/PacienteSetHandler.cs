using Domain.Excepcions;
using Domain.Repositorio;
using Domain.ValueObject;
using MediatR;

namespace Application.Pacientes.Command.Set
{
    public class PacienteSetHandler : IRequestHandler<PacienteSetCommand, PacienteSetResponse>
    {
        private readonly IPacienteRepository _repository;
        public PacienteSetHandler(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<PacienteSetResponse> Handle(PacienteSetCommand request, CancellationToken cancellationToken)
        {
            var rut = new DocumentoIdentidad(request.Rut);
            var paciente = await _repository.GetByRutPaciente(request.Rut);
            if (paciente == null)
                throw new NotFoundException($"paciente Rut:{request.Rut}");
            paciente.SetPaciente(request.Direccion, request.Alergias, request.Celular, request.IdComuna);
            await _repository.SetPacienteAsync(paciente);

            return new PacienteSetResponse()
            {
                Id = paciente.IdPaciente,
                FechaModificacion = paciente.FechaModificacion
            };
        }
    }
}
