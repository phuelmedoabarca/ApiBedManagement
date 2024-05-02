using Domain.Entities;
using Domain.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura
{
    public class SalaRepository : ISalaRepository
    {
        private readonly DataBaseContext _dataBase;
        public SalaRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<List<Sala>> GetListByUnidad(int idUnidad)
        {
            var salas = await _dataBase.Sala
                           .Where(s => s.IdUnidad == idUnidad)
                           .ToListAsync();
            return salas;
        }
    }
}
