using Domain.Entities;
using Domain.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly DataBaseContext _dataBase;
        public PacienteRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }
        public async Task AddPacienteAsync(Paciente paciente)
        {
            await _dataBase.Set<Paciente>().AddAsync(paciente);
            await _dataBase.SaveChangesAsync();
        }
        public async Task SetPacienteAsync(Paciente paciente)
        {
            _dataBase.Set<Paciente>().Update(paciente);
            await _dataBase.SaveChangesAsync();
        }
        public async Task<Paciente?> GetByRutPaciente(string rut)
        {
            var paciente = await _dataBase.Set<Paciente>()
                            .SingleOrDefaultAsync(i => i.Rut.Documento == rut);
            return paciente;
        }

        public async Task<List<Paciente>> GetListPaciente()
        {
            return await _dataBase.Paciente.ToListAsync();
        }

        public async Task<Paciente?> GetByIdPaciente(Guid id)
        {
            var paciente = await _dataBase.Set<Paciente>()
                            .SingleOrDefaultAsync(i => i.IdPaciente == id);
            return paciente;
        }
    }
}
