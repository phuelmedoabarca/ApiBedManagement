using Domain.Entities;

namespace Domain.Repositorio
{
    public interface ICamaRepository
    {
        Task<List<Cama>> GetListBySala(int idSala);
    }
}
