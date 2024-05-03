using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ingresos.Command.Set
{
    public class IngresoSetResponse
    {
        public Guid Id { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
