using Domain.Entities;
using Domain.Excepcions;
using Domain.Repositorio;
using Domain.ValueObject;
using MediatR;

namespace Application.Pacientes.Queries.GetByRutPaciente
{
    public class GetByRutPacienteHandler : IRequestHandler<GetByRutPacienteQuery, Paciente>
    {
        private readonly IPacienteRepository _repository;
        public GetByRutPacienteHandler(IPacienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<Paciente> Handle(GetByRutPacienteQuery request, CancellationToken cancellationToken)
        {
            var rut = new DocumentoIdentidad(request.Rut);
            var paciente = await _repository.GetByRutPaciente(request.Rut);
            if (paciente == null)
                throw new NotFoundException($"paciente Rut:{request.Rut}");
            return paciente;
        }
    }
}
