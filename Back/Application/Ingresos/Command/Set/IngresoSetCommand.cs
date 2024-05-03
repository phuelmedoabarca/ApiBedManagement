using MediatR;

namespace Application.Ingresos.Command.Set
{
    public class IngresoSetCommand : IRequest<IngresoSetResponse>
    {
        public Guid IdIngreso { get; set; }
        public string? Diagnostico { get; set; }
        public DateTime? FechaAlta { get; set; }
        public Guid IdUsuario { get; set; }
        public int? IdCama { get; set; }
        public int? IdUnidad { get; set; }
    }
}
