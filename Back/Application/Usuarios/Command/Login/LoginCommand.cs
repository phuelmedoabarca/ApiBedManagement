using MediatR;

namespace Application.Usuarios.Command.Login
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Contrasena { get; set; }
    }
}
