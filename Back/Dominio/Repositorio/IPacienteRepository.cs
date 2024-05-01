using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorio
{
    public interface IPacienteRepository
    {
        Task AddPacienteAsync(Paciente paciente);
        Task SetPacienteAsync(Paciente paciente);
        Task<Paciente?> GetByRutPaciente(string rut);
        Task<List<Paciente>> GetListPaciente();
    }
}
