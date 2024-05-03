using Domain.Entities;
using Domain.Excepcions;
using Domain.Repositorio;
using MediatR;

namespace Application.Ingresos.Queries.GetByIdIngreso
{
    public class GetByIdIngresoHandler : IRequestHandler<GetByIdIngresoQuery, Ingreso>
    {
        private readonly IIngresoRepository _repository;
        public GetByIdIngresoHandler(IIngresoRepository repository)
        {
            _repository = repository;
        }
        public async Task<Ingreso> Handle(GetByIdIngresoQuery request, CancellationToken cancellationToken)
        {
            var ingreso = await _repository.GetByIdIngreso(request.IdIngreso);
            if (ingreso == null)
                throw new NotFoundException($"ingreso Id:{request.IdIngreso}");
            return ingreso;
        }
    }
}
