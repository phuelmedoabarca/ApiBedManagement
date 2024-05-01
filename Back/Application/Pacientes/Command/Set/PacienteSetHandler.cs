using Application.Pacientes.Command.Create;
using Domain.Entities;
using Domain.Excepcions;
using Domain.Repositorio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pacientes.Command.Set
{
    public class PacienteSetHandler : IRequestHandler<PacienteSetCommand, PacienteSetResponse>
    {
        private readonly IPacienteRepository _repository;
        public PacienteSetHandler(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<PacienteSetResponse> Handle(PacienteSetCommand request, CancellationToken cancellationToken)
        {
            var paciente = await _repository.GetByRutPaciente(request.Rut);
            if (paciente == null)
                throw new NotFoundException($"paciente Rut:{request.Rut}");
            paciente.SetPaciente(request.Direccion, request.Alergias, request.Celular, request.IdComuna);
            await _repository.SetPacienteAsync(paciente);

            return new PacienteSetResponse()
            {
                Id = paciente.IdPaciente,
                FechaModificacion = paciente.FechaModificacion
            };
        }
    }
}
