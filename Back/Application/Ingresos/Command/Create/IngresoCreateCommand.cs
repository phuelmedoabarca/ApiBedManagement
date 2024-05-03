using MediatR;

namespace Application.Ingresos.Command.Create
{
    public class IngresoCreateCommand : IRequest<IngresoCreateResponse>
    {
        public string Sintomas { get; set; }
        public Guid IdPaciente { get; set; }
        public Guid IdUsuario { get; set; }
    }
}
