using Domain.Entities;
using MediatR;

namespace Application.Ingresos.Queries.GetByIdIngreso
{
    public class GetByIdIngresoQuery : IRequest<Ingreso>
    {
        public Guid IdIngreso { get; set; }
    }
}
