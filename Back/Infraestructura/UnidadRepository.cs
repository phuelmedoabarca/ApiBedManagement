using Domain.Entities;
using Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
