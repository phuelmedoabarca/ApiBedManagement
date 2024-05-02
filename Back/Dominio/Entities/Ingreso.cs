
namespace Domain.Entities
{
    public class Ingreso
    {
        public Ingreso() { }
        public Ingreso(Guid id, string sintomas, Guid idPaciente, Guid idUsuario) 
        {
            IdIngreso = id;
            Sintomas = sintomas;
            IdPaciente = idPaciente;
            IdUsuario = idUsuario;
        }
        public Guid IdIngreso { get; set; }
        public string Sintomas { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string Diagnostico { get; set; }
        public Guid IdPaciente { get; set; }
        public Guid IdUsuario { get; set; }
        public int IdEstado { get; set; }
        public int? IdCama { get; set; }
        public int? IdUnidad { get; set; }
        public static Ingreso Create(Guid id, string sintomas, Guid idPaciente, Guid idUsuario)
        {
            var ingreso = new Ingreso(id, sintomas, idPaciente, idUsuario);
            ingreso.FechaCreacion = DateTime.Now;
            ingreso.IdEstado = 1;
            return ingreso;
        }
    }
}
