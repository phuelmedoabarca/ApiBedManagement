using Domain.Entities;
using MediatR;

namespace Application.Usuarios.Queries.GetList
{
    public class GetListUsuarioQuery : IRequest<List<Usuario>>
    {
    }
}
