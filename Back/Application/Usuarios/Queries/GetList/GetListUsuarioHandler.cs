using Application.Pacientes.Queries.GetList;
using Domain.Entities;
using Domain.Repositorio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.Queries.GetList
{
    public class GetListUsuarioHandler : IRequestHandler<GetListUsuarioQuery, List<Usuario>>
    {
        private readonly IUsuarioRepository _repository;
        public GetListUsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Usuario>> Handle(GetListUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _repository.GetListUsuario();
            return usuarios;
        }
    }
}
