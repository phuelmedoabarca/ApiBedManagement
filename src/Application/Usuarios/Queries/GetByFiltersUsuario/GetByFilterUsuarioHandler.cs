using Application.Usuarios.Queries.GetByRutUsuario;
using Domain.Entities;
using Domain.Repositorio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.Queries.GetByFiltersUsuario
{
    public class GetByFilterUsuarioHandler : IRequestHandler<GetByFilterUsuarioQuery, List<Usuario>>
    {
        private readonly IUsuarioRepository _repository;
        public GetByFilterUsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Usuario>> Handle(GetByFilterUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _repository.GetListUsuarioWhitFilters(request.Rut, request.Nombre);
            return usuarios;
        }
    }
}
