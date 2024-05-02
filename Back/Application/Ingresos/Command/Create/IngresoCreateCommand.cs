using Application.Pacientes.Command.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ingresos.Command.Create
{
    public class IngresoCreateCommand : IRequest<IngresoCreateResponse>
    {
        public string Sintomas { get; set; }
        public Guid IdPaciente { get; set; }
        public Guid IdUsuario { get; set; }
    }
}
