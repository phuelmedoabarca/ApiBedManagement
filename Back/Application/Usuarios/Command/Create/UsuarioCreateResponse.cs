using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.Command.Create
{
    public class UsuarioCreateResponse
    {
        public Guid Id { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
