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
    public class ComunaRepository : IComunaRepository
    {
        private readonly DataBaseContext _dataBase;
        public ComunaRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }
        public async Task<List<Comuna>> GetListComuna()
        {
            return await _dataBase.Comuna.ToListAsync();
        }
    }
}
