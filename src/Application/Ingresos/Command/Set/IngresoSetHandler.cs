using Application.Ingresos.Command.Create;
using Domain.Entities;
using Domain.Excepcions;
using Domain.Repositorio;
using Infraestructura;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ingresos.Command.Set
{
    public class IngresoSetHandler : IRequestHandler<IngresoSetCommand, IngresoSetResponse>
    {
        private readonly IIngresoRepository _repository;
        private readonly ICamaRepository _camaRepository;
        public IngresoSetHandler(IIngresoRepository repository, ICamaRepository camaRepository)
        {
            _repository = repository;
            _camaRepository = camaRepository;
        }
        public async Task<IngresoSetResponse> Handle(IngresoSetCommand request, CancellationToken cancellationToken)
        {
            int? camaAlta = 0;
            var ingreso = await _repository.GetByIdIngreso(request.IdIngreso);
            if (ingreso == null)
                throw new NotFoundException($"ingreso Id:{request.IdIngreso}");

            if (request.FechaAlta != null) 
            {
                camaAlta = ingreso.IdCama;
            }

            ingreso.SetIngreso(request.Diagnostico, request.FechaAlta, request.IdCama, request.IdUnidad, request.IdUsuario);
            if (request.IdCama > 0 && ingreso.IdEstado == 3)
            {
                var cama = await _camaRepository.GetById(request.IdCama);
                if (cama == null)
                    throw new NotFoundException($"cama Id:{request.IdCama}");
                cama.SetEstadoCama(2);
            }

            if (ingreso.IdEstado == 4)
            {
                var cama = await _camaRepository.GetById(camaAlta);
                if (cama == null)
                    throw new NotFoundException($"cama Id:{camaAlta}");
                cama.SetEstadoCama(1);
            }

            await _repository.SetIngresoAsync(ingreso);

            return new IngresoSetResponse()
            {
                Id = ingreso.IdIngreso,
                Message = "Paciente modificado exitosamente",
                FechaModificacion = ingreso.FechaModificacion
            };
        }
    }
}
