using Domain.Entities;

namespace Domain.Repositorio
{
    public interface IIngresoRepository
    {
        Task AddIngresoAsync(Ingreso ingreso);
        Task SetIngresoAsync(Ingreso ingreso);
        Task<Ingreso?> GetByIdIngreso(Guid id);
        Task<List<Ingreso>> GetListIngreso(int idEstado);
    }
}
