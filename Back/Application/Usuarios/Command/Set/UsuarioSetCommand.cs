using Application.Pacientes.Command.Set;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
