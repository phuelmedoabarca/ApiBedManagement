using Domain.Entities;
using MediatR;

namespace Application.Pacientes.Queries.GetList
{
    public class GetListPacienteQuery : IRequest<List<Paciente>>
    {
    }
}
