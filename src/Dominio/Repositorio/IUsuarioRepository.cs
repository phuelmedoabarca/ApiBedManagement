using Domain.Entities;

namespace Domain.Repositorio
{
    public interface IUsuarioRepository
    {
        Task AddUsuarioAsync(Usuario usuario);
        Task SetUsuarioAsync(Usuario usuario);
        Task DeleteByRutUsuarioAsync(Usuario usuario);
        Task<Usuario?> GetByRutUsuario(string rut);
        Task<Usuario?> GetByEmailUsuario(string email);
        Task<Usuario?> GetByIdUsuario(Guid id);
        Task<List<Usuario>> GetListUsuario();
        Task<List<Usuario>> GetListUsuarioWhitFilters(string rut, string nombre);
    }
}
