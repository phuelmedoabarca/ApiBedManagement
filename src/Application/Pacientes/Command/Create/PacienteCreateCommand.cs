using MediatR;

namespace Application.Pacientes.Command.Create
{
    public class PacienteCreateCommand : IRequest<PacienteCreateResponse>
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string Alergias { get; set; }
        public int Celular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdComuna { get; set; }
    }
}
