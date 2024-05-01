using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pacientes.Queries.GetByRutPaciente
{
    public class GetByRutPacienteQuery : IRequest<Paciente>
    {
        public string Rut { get; set; }
    }
}
