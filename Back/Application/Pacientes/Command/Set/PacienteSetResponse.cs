using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pacientes.Command.Set
{
    public class PacienteSetResponse
    {
        public Guid Id { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
