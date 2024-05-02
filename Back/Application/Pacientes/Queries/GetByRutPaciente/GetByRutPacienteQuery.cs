using Domain.Entities;
using MediatR;

namespace Application.Pacientes.Queries.GetByRutPaciente
{
    public class GetByRutPacienteQuery : IRequest<Paciente>
    {
        public string Rut { get; set; }
    }
}
