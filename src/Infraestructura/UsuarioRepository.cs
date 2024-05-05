using Domain.Entities;
using Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public async Task<Usuario?> GetByEmailUsuario(string enail)
        {
            var usuario = await _dataBase.Set<Usuario>()
                .SingleOrDefaultAsync(i => i.Email.Email == enail);
            return usuario;
        }

        public async Task<List<Usuario>> GetListUsuario()
        {
            var usuarios = await _dataBase.Set<Usuario>()
                                .Include(i => i.Rol)
                                .ToListAsync();
            return usuarios;

        }
        public async Task<List<Usuario>> GetListUsuarioWhitFilters(string rut, string nombre)
        {
            var query = _dataBase.Set<Usuario>()
                                .Include(i => i.Rol)
                                .AsQueryable();

            if (!string.IsNullOrEmpty(rut))
            {
                query = query.Where(x => x.Rut.Documento.Contains(rut));
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(x => x.Nombre.Contains(nombre));
            }

            var usuarios = await query.ToListAsync();
            return usuarios;

        }

        public async Task SetUsuarioAsync(Usuario usuario)
        {
            _dataBase.Set<Usuario>().Update(usuario);
            await _dataBase.SaveChangesAsync();
        }
    }
}
