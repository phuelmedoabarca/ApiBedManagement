using Domain.Entities;
using MediatR;

namespace Application.Usuarios.Queries.GetByFiltersUsuario
{
    public class GetByFilterUsuarioQuery : IRequest<List<Usuario>>
    { 
        public string Rut { get; set; }
        public string Nombre { get; set; }
    }
}
