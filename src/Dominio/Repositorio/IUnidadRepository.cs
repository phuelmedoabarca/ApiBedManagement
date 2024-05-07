using Domain.Entities;

namespace Domain.Repositorio
{
    public interface IUnidadRepository
    {
        Task<List<Unidad>> GetListUnidad();
    }
}
