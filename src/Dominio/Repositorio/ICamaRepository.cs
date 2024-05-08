using Domain.Entities;

namespace Domain.Repositorio
{
    public interface ICamaRepository
    {
        Task<List<Cama>> GetListBySala(int idSala);
        Task<Cama?> GetById(int? idCama);
        Task SetEstadoCamaAsync(Cama cama);
        Task<int> GetCountCamasByUnidad(int idUnidad);
    }
}
