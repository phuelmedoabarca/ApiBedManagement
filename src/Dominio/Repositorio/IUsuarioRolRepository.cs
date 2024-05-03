using Domain.Entities;

namespace Domain.Repositorio
{
    public interface IUsuarioRolRepository
    {
        Task<List<UsuarioRol>> GetListRoles();
    }
}
