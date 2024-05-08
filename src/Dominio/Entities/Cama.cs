
namespace Domain.Entities
{
    public class Cama
    {
        public int IdCama { get; }
        public int Numero { get; }
        public string Sexo { get; }
        public int IdSala { get; set; }
        public Sala Sala { get; }
        public int IdEstadoCama { get; set; }
        public void SetEstadoCama(int idEstadoCama)
        {
            IdEstadoCama = idEstadoCama;
        }
    }
}
