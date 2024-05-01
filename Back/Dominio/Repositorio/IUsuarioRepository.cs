using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorio
{
    public interface IUsuarioRepository
    {
        Task AddUsuarioAsync(Usuario usuario);
        Task SetUsuarioAsync(Usuario usuario);
        Task<Usuario?> GetByRutUsuario(string rut);
        Task<List<Usuario>> GetListUsuario();
    }
}
