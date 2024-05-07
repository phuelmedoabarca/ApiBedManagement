using Domain.Excepcions;
using Domain.ValueObject;

namespace Domain.Entities
{
    public class Paciente
    {
        public Paciente() { }
        public Paciente(Guid id, DocumentoIdentidad rut, string nombre, string sexo, string direccion, string alergias, int celular, DateTime fechaNacimiento, int idComuna) 
        {
            IdPaciente = id;
            Rut = rut;
            Nombre = nombre;
            Sexo = sexo;
            Direccion = direccion;
            Alergias = alergias;
            Celular = celular;
            FechaNacimiento = fechaNacimiento;
            IdComuna = idComuna;
        }
        public Guid IdPaciente { get; set; }
        public DocumentoIdentidad Rut { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string Alergias { get; set; }
        public int Celular { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdComuna { get; set; }
        public static Paciente Create(Guid id, DocumentoIdentidad rut, string nombre, string sexo, string direccion, string alergias, int celular, DateTime fechaNacimiento, int idComuna)
        {
            if((string.IsNullOrEmpty(nombre)) || (string.IsNullOrEmpty(sexo)) || (string.IsNullOrEmpty(direccion)) || celular.ToString().Length != 9)
                throw new BadRequestException("Debe ingresar todos los campos.");

            var paciente = new Paciente(id, rut, nombre, sexo, direccion, alergias, celular, fechaNacimiento, idComuna);
            paciente.FechaCreacion = DateTime.UtcNow;

            return paciente;
        }
        public void SetPaciente(string direccion, string alergias, int celular, int idComuna)
        {
            if ((string.IsNullOrEmpty(direccion)) || (string.IsNullOrEmpty(direccion)) || celular.ToString().Length != 9)
                throw new BadRequestException("Debe ingresar todos los campos.");
            Direccion = direccion;
            Alergias = alergias;
            Celular = celular; 
            IdComuna = idComuna;
            FechaModificacion = DateTime.UtcNow;
        }
    }
}
