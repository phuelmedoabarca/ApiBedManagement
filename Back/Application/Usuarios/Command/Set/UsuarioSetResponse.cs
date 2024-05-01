using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.Command.Set
{
    public class UsuarioSetResponse
    {
        public Guid Id { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
