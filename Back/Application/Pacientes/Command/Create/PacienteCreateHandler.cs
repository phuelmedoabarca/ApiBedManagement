using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using System.Reflection.Metadata;
using Domain.ValueObject;
using Infraestructura;
using Domain.Repositorio;
using Domain.Excepcions;

namespace Application.Pacientes.Command.Create
{
    public class PacienteCreateHandler : IRequestHandler<PacienteCreateCommand, PacienteCreateResponse>
    {
        private readonly IPacienteRepository _repository;
        public PacienteCreateHandler(IPacienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<PacienteCreateResponse> Handle(PacienteCreateCommand request, CancellationToken cancellationToken)
        {
            var paciente = await CreatePaciente(request);
            await _repository.AddPacienteAsync(paciente);

            return new PacienteCreateResponse()
            {
                Id = paciente.IdPaciente,
                FechaCreacion = paciente.FechaCreacion
            };
        }
        public async Task<Paciente> CreatePaciente(PacienteCreateCommand request)
        {
            var rut = new DocumentoIdentidad(request.Rut);
            var paciente = Paciente.Create(Guid.NewGuid(), rut, request.Nombre, request.Sexo, request.Direccion, request.Alergias, request.Celular, request.FechaNacimiento, request.IdComuna);
            return paciente;
        }
    }
}
