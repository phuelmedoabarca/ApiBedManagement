using Application.Usuarios.Queries.GetByFiltersUsuario;
using Domain.Entities;
using Domain.Repositorio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ingresos.Queries.GetByFiltersIngreso
{
    public class GetByFilterIngresoHandler : IRequestHandler<GetByFilterIngresoQuery, List<Ingreso>>
    {
        private readonly IIngresoRepository _repository;
        public GetByFilterIngresoHandler(IIngresoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Ingreso>> Handle(GetByFilterIngresoQuery request, CancellationToken cancellationToken)
        {
            var ingresos = await _repository.GetListIngresoWhitFilters(request.Rut, request.Nombre);
            return ingresos;
        }
    }
}
