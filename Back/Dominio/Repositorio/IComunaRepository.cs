using Domain.Entities;

namespace Domain.Repositorio
{
    public interface IComunaRepository
    {
        Task<List<Comuna>> GetListComuna();
    }
}
