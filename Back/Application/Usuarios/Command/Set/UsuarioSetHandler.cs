using Application.Pacientes.Command.Set;
using Domain.Excepcions;
using Domain.Repositorio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.Command.Set
{
    public class UsuarioSetHandler : IRequestHandler<UsuarioSetCommand, UsuarioSetResponse>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioRolRepository _rolRepository;
        public UsuarioSetHandler(IUsuarioRepository repository, IUsuarioRolRepository rolRepository)
        {
            _repository = repository;
            _rolRepository = rolRepository;
        }

        public async Task<UsuarioSetResponse> Handle(UsuarioSetCommand request, CancellationToken cancellationToken)
        {
            var roles = await _rolRepository.GetListRoles();
            var existRol = roles.FirstOrDefault(x => x.IdRol == request.IdRol);
            if (existRol == null)
                throw new NotFoundException($"Rol:{request.IdRol}");

            var usuario = await _repository.GetByRutUsuario(request.Rut);
            if (usuario == null)
                throw new NotFoundException($"usuario Rut:{request.Rut}");
            usuario.SetUsuario(request.Nombre, request.Contrasena, request.Email, request.IdRol);
            await _repository.SetUsuarioAsync(usuario);

            return new UsuarioSetResponse()
            {
                Id = usuario.IdUsuario,
                FechaModificacion = usuario.FechaModificacion
            };
        }
    }
}
