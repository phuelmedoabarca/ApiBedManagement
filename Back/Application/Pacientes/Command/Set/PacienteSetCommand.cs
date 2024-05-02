using MediatR;

namespace Application.Pacientes.Command.Set
{
    public class PacienteSetCommand : IRequest<PacienteSetResponse>
    {
        public string Rut { get; set; }
        public string Direccion { get; set; }
        public string Alergias { get; set; }
        public int Celular { get; set; }
        public int IdComuna { get; set; }
    }
}
