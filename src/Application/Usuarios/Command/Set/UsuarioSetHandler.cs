using Domain.Excepcions;
using Domain.Repositorio;
using Domain.ValueObject;
using MediatR;

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
            var rut = new DocumentoIdentidad(request.Rut);
            var usuario = await _repository.GetByRutUsuario(request.Rut);
            if (usuario == null)
                throw new NotFoundException($"usuario Rut:{request.Rut}");

            var roles = await _rolRepository.GetListRoles();
            var existRol = roles.FirstOrDefault(x => x.IdRol == request.IdRol);
            if (existRol == null)
                throw new NotFoundException($"rol: {request.IdRol}");

            var usuarioEmail = await _repository.GetByEmailUsuario(request.Email);
            if (usuarioEmail is not null)
                throw new BadRequestException($"Usuario con el email: {request.Email} ya existe.");

            if (request.Contrasena.Length < 6)
                throw new BadRequestException("Contraseña debe tener minimo 6 caracteres.");

            usuario.SetUsuario(request.Nombre, request.Contrasena, request.Email, request.IdRol);
            await _repository.SetUsuarioAsync(usuario);

            return new UsuarioSetResponse()
            {
                Id = usuario.IdUsuario,
                Message = "Usuario modificado exitosamente.",
                FechaModificacion = usuario.FechaModificacion
            };
        }
    }
}
