using Domain.Entities;
using Domain.Repositorio;
using MediatR;

namespace Application.Ingresos.Queries.GetList
{
    public class GetListIngresoHandler : IRequestHandler<GetListIngresoQuery, List<Ingreso>>
    {
        private readonly IIngresoRepository _repository;
        public GetListIngresoHandler(IIngresoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Ingreso>> Handle(GetListIngresoQuery request, CancellationToken cancellationToken)
        {
            var ingreso = await _repository.GetListIngreso(request.IdEstado);
            return ingreso;
        }
    }
}
