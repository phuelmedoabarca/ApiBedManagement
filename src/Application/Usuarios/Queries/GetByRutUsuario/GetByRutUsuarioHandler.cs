﻿using Domain.Entities;
using Domain.Excepcions;
using Domain.Repositorio;
using Domain.ValueObject;
using MediatR;

namespace Application.Usuarios.Queries.GetByRutUsuario
{
    public class GetByRutUsuarioHandler : IRequestHandler<GetByRutUsuarioQuery, Usuario>
    {
        private readonly IUsuarioRepository _repository;
        public GetByRutUsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Usuario> Handle(GetByRutUsuarioQuery request, CancellationToken cancellationToken)
        {
            var rut = new DocumentoIdentidad(request.Rut);
            var usuario = await _repository.GetByRutUsuario(request.Rut);
            if (usuario == null)
                throw new NotFoundException($"usuario Rut:{request.Rut}");
            return usuario;
        }
    }
}
