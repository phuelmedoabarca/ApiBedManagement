using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cama
    {
        public int IdCama { get; }
        public int Numero { get; }
        public string Sexo { get; }
        public int IdSala { get; }
        public int IdEstadoCama { get; }
    }
}
