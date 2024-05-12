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
            rut = rut.Replace(".", "").ToUpper();
            var rutParts = rut.Split('-');
            int documento = int.Parse(rutParts[0]);
            string digito = rutParts[1];
            var usuario = await _dataBase.Set<Usuario>()
                .SingleOrDefaultAsync(i => i.Rut.Documento == documento && i.Rut.Digito == digito);
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
                if(!rut.Contains("-") && !rut.Contains("."))
                    query = query.Where(x => x.Rut.Documento.ToString().Contains(rut.ToString()));
                if (rut.Contains(".")) 
                    rut = rut.Replace(".", "").ToUpper();
                if (rut.Contains("-"))
                {
                    var rutParts = rut.Split('-');
                    int documento = int.Parse(rutParts[0]);
                    string digito = rutParts[1];
                    if (string.IsNullOrEmpty(digito))
                    {
                        query = query.Where(x => x.Rut.Documento == documento);
                    }
                    else
                    {
                        query = query.Where(x => x.Rut.Documento == documento && x.Rut.Digito == digito);
                    }
                }
                else
                {
                    query = query.Where(x => x.Rut.Documento.ToString().Contains(rut.ToString()));
                }
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
