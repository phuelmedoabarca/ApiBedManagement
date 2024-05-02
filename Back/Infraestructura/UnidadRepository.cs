using Domain.Entities;
using Domain.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura
{
    public class UnidadRepository : IUnidadRepository
    {
        private readonly DataBaseContext _dataBase;
        public UnidadRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }
        public async Task<List<Unidad>> GetListUnidad()
        {
            return await _dataBase.Unidad.ToListAsync();
        }
    }
}
