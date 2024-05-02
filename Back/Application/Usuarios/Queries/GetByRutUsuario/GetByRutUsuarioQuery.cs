using Domain.Entities;
using MediatR;

namespace Application.Usuarios.Queries.GetByRutUsuario
{
    public class GetByRutUsuarioQuery : IRequest<Usuario>
    {
        public string Rut { get; set; }
    }
}
