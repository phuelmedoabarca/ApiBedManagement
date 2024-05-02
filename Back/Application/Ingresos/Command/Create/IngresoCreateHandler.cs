using Domain.Entities;
using Domain.Excepcions;
using Domain.Repositorio;
using MediatR;

namespace Application.Ingresos.Command.Create
{
    public class IngresoCreateHandler : IRequestHandler<IngresoCreateCommand, IngresoCreateResponse>
    {
        private readonly IIngresoRepository _repository;
        private readonly IPacienteRepository _pacientRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public IngresoCreateHandler(IIngresoRepository repository, IPacienteRepository pacientRepository, IUsuarioRepository usuarioRepository)
        {
            _repository = repository;
            _pacientRepository = pacientRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IngresoCreateResponse> Handle(IngresoCreateCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdUsuario(request.IdUsuario);
            if (usuario == null)
                throw new NotFoundException($"usuario Id:{request.IdUsuario}");

            var paciente = await _pacientRepository.GetByIdPaciente(request.IdPaciente);
            if (paciente == null)
                throw new NotFoundException($"paciente Id:{request.IdUsuario}");

            var ingreso = await CreateIngreso(request);
            await _repository.AddIngresoAsync(ingreso);

            return new IngresoCreateResponse()
            {
                Id = ingreso.IdIngreso,
                FechaCreacion = ingreso.FechaCreacion
            };
        }
        public async Task<Ingreso> CreateIngreso(IngresoCreateCommand request)
        {
            var ingreso = Ingreso.Create(Guid.NewGuid(), request.Sintomas, request.IdPaciente, request.IdUsuario);
            return ingreso;
        }
    }
}
