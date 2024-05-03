using Domain.Entities;
using Domain.Repositorio;
using MediatR;

namespace Application.Pacientes.Queries.GetList
{
    public class GetListPacienteHandler : IRequestHandler<GetListPacienteQuery, List<Paciente>>
    {
        private readonly IPacienteRepository _repository;
        public GetListPacienteHandler(IPacienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Paciente>> Handle(GetListPacienteQuery request, CancellationToken cancellationToken)
        {
            var pacientes = await _repository.GetListPaciente();
            return pacientes;
        }
    }
}
