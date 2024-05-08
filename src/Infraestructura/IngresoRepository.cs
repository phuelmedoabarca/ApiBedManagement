using Domain.Entities;
using Domain.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura
{
    public class IngresoRepository : IIngresoRepository
    {
        private readonly DataBaseContext _dataBase;
        public IngresoRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }
        public async Task AddIngresoAsync(Ingreso ingreso)
        {
            await _dataBase.Set<Ingreso>().AddAsync(ingreso);
            await _dataBase.SaveChangesAsync();
        }

        public async Task<Ingreso?> GetByIdIngreso(Guid id)
        {
            var ingreso = await _dataBase.Set<Ingreso>()
                            .Include(i => i.Paciente)
                            .SingleOrDefaultAsync(i => i.IdIngreso == id);
            return ingreso;
        }

        public async Task<List<Ingreso>> GetListIngreso()
        {
            var ingresos = await _dataBase.Set<Ingreso>()
                                            .Include(i => i.Paciente) 
                                            .Include(i => i.Unidad)
                                            .ToListAsync();
            return ingresos;
        }

        public async Task<List<Ingreso>> GetListIngresoWhitFilters(string rut, string nombre)
        {
            var query = _dataBase.Set<Ingreso>()
                    .Include(i => i.Paciente)
                    .Include(i => i.Unidad)
                    .AsQueryable();

            if (!string.IsNullOrEmpty(rut))
            {
                query = query.Where(x => x.Paciente.Rut.Documento.Contains(rut));
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(x => x.Paciente.Nombre.Contains(nombre));
            }

            var ingresos = await query.ToListAsync();
            return ingresos;
        }

        public async Task SetIngresoAsync(Ingreso ingreso)
        {
            _dataBase.Set<Ingreso>().Update(ingreso);
            await _dataBase.SaveChangesAsync();
        }
    }
}
