using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ingresos.Queries.GetByFiltersIngreso
{
    public class GetByFilterIngresoQuery : IRequest<List<Ingreso>>
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
    }
}
