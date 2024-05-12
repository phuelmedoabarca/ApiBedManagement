using Domain.Entities;
using Domain.Excepcions;
using Domain.Repositorio;
using Domain.ValueObject;
using MediatR;

namespace Application.Usuarios.Command.Create
{
    public class UsuarioCreateHandler : IRequestHandler<UsuarioCreateCommand, UsuarioCreateResponse>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioRolRepository _rolRepository;
        public UsuarioCreateHandler(IUsuarioRepository repository, IUsuarioRolRepository rolRepository)
        {
            _repository = repository;
            _rolRepository = rolRepository;
        }

        public async Task<UsuarioCreateResponse> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            var roles = await _rolRepository.GetListRoles();
            var existRol = roles.FirstOrDefault(x => x.IdRol == request.IdRol);
            if (existRol == null)
                throw new NotFoundException($"rol: {request.IdRol}");

            var usuario = await CreateUsuario(request);
            await _repository.AddUsuarioAsync(usuario);

            return new UsuarioCreateResponse()
            {
                Id = usuario.IdUsuario,
                Message = "Usuario creado exitosamente.",
                FechaCreacion = usuario.FechaCreacion
            };
        }
        public async Task<Usuario> CreateUsuario(UsuarioCreateCommand request)
        {
            var rut = new DocumentoIdentidad(request.Rut);
            var email = new ContactoEmail(request.Email);
            var usuario = Usuario.Create(Guid.NewGuid(), rut, request.Nombre, request.Contrasena, email, request.IdRol);

            if (request.Contrasena.Length < 6)
                throw new BadRequestException("Contraseña debe tener minimo 6 caracteres.");

            var usuarioRut = await _repository.GetByRutUsuario(request.Rut);
            if(usuarioRut is not null)
                throw new BadRequestException($"Usuario con el Rut: {request.Rut} ya existe.");

            var usuarioEmail = await _repository.GetByEmailUsuario(request.Email);
            if (usuarioEmail is not null)
                throw new BadRequestException($"Usuario con el email: {request.Email} ya existe.");

            return usuario;
        }
    }
}
