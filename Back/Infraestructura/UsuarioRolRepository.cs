using Domain.Entities;
using Domain.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura
{
    public class UsuarioRolRepository : IUsuarioRolRepository
    {
        private readonly DataBaseContext _dataBase;
        public UsuarioRolRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }
        public async Task<List<UsuarioRol>> GetListRoles()
        {
            return await _dataBase.UsuarioRol.ToListAsync();
        }
    }
}
