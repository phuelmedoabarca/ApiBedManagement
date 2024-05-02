using MediatR;

namespace Application.Usuarios.Command.Set
{
    public class UsuarioSetCommand : IRequest<UsuarioSetResponse>
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Email { get; set; }
        public Guid IdRol { get; set; }
    }
}
