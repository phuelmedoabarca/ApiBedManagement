using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ingresos.Command.Create
{
    public class IngresoCreateResponse
    {
        public Guid Id { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
