using Domain.Entities;
using MediatR;

namespace Application.Ingresos.Queries.GetList
{
    public class GetListIngresoQuery : IRequest<List<Ingreso>>
    {
        public int IdEstado { get; set; }
    }
}
