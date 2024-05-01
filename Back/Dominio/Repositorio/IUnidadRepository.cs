using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorio
{
    public interface IUnidadRepository
    {
        Task<List<Unidad>> GetListUnidad();
    }
}
