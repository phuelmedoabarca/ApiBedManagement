using Domain.Excepcions;
using Domain.Repositorio;
using Domain.ValueObject;
using MediatR;

namespace Application.Usuarios.Command.Delete
{
    public class UsuarioDeleteHandler : IRequestHandler<UsuarioDeleteCommand, UsuarioDeleteResponse>
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioDeleteHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<UsuarioDeleteResponse> Handle(UsuarioDeleteCommand request, CancellationToken cancellationToken)
        {
            var rut = new DocumentoIdentidad(request.Rut);
            var usuario = await _repository.GetByRutUsuario(request.Rut);
            if (usuario == null)
                throw new NotFoundException($"usuario Rut:{request.Rut}");

            await _repository.DeleteByRutUsuarioAsync(usuario);

            return new UsuarioDeleteResponse()
            {
                Id = usuario.IdUsuario,
                Message = "Usuario eliminado exitosamente.",
                FechaEliminacion = DateTime.UtcNow
            };
        }
    }
}
