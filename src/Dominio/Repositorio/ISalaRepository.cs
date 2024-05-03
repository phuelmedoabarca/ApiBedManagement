using Domain.Entities;

namespace Domain.Repositorio
{
    public interface ISalaRepository
    {
        Task<List<Sala>> GetListByUnidad(int idUnidad);
    }
}
