using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pacientes.Command.Create
{
    public class PacienteCreateCommand : IRequest<PacienteCreateResponse>
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string Alergias { get; set; }
        public int Celular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdComuna { get; set; }
    }
}
