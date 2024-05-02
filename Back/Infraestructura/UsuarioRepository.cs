using Domain.Entities;
using Domain.Repositorio;
using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteByRutUsuarioAsync(Usuario usuario)
        {
            _dataBase.Set<Usuario>().Remove(usuario);
            await _dataBase.SaveChangesAsync();
        }

        public async Task<Usuario?> GetByIdUsuario(Guid id)
        {
            var usuario = await _dataBase.Set<Usuario>()
                                    .SingleOrDefaultAsync(i => i.IdUsuario == id);
            return usuario;
        }

        public async Task<Usuario?> GetByRutUsuario(string rut)
        {
            var usuario = await _dataBase.Set<Usuario>()
                .SingleOrDefaultAsync(i => i.Rut.Documento == rut);
            return usuario;
        }

        public async Task<List<Usuario>> GetListUsuario()
        {
            return await _dataBase.Usuario.ToListAsync();
        }

        public async Task SetUsuarioAsync(Usuario usuario)
        {
            _dataBase.Set<Usuario>().Update(usuario);
            await _dataBase.SaveChangesAsync();
        }
    }
}
