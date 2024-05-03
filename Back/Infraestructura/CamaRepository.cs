using Domain.Entities;
using Domain.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura
{
    public class CamaRepository : ICamaRepository
    {
        private readonly DataBaseContext _dataBase;
        public CamaRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<Cama?> GetById(int? idCama)
        {
            var cama = await _dataBase.Set<Cama>()
                .SingleOrDefaultAsync(i => i.IdCama == idCama);
            return cama;
        }

        public async Task<List<Cama>> GetListBySala(int idSala)
        {
            var camas = await _dataBase.Cama
                           .Where(s => s.IdSala == idSala && s.IdEstadoCama == 1)
                           .ToListAsync();
            return camas;
        }
        public async Task SetEstadoCamaAsync(Cama cama)
        {
            _dataBase.Set<Cama>().Update(cama);
            await _dataBase.SaveChangesAsync();
        }
    }
}
