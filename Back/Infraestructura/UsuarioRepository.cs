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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataBaseContext _dataBase;
        public UsuarioRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }
        public async Task AddUsuarioAsync(Usuario usuario)
        {
            await _dataBase.Set<Usuario>().AddAsync(usuario);
            await _dataBase.SaveChangesAsync();
        }

        public async Task<Usuario?> GetByRutUsuario(string rut)
        {
            var usuario = await _dataBase.Set<Usuario>()
                .SingleOrDefaultAsync(i => i.Rut.Documento == rut);
            return usuario;
        }

        public Task<List<Usuario>> GetListUsuario()
        {
            throw new NotImplementedException();
        }

        public async Task SetUsuarioAsync(Usuario usuario)
        {
            _dataBase.Set<Usuario>().Update(usuario);
            await _dataBase.SaveChangesAsync();
        }
    }
}
