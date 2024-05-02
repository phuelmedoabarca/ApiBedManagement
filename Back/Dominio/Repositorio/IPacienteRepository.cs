using Domain.Entities;

namespace Domain.Repositorio
{
    public interface IPacienteRepository
    {
        Task AddPacienteAsync(Paciente paciente);
        Task SetPacienteAsync(Paciente paciente);
        Task<Paciente?> GetByRutPaciente(string rut);
        Task<Paciente?> GetByIdPaciente(Guid id);
        Task<List<Paciente>> GetListPaciente();
    }
}
