using MediatR;

namespace Application.Usuarios.Command.Delete
{
    public class UsuarioDeleteCommand : IRequest<UsuarioDeleteResponse>
    {
        public string Rut { get; set; }
    }
}
