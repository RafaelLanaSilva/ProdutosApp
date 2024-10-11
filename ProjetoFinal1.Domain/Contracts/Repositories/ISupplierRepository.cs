using ProjetoFinal1.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Domain.Contracts.Repositories
{
    public interface ISupplierRepository : IBaseRepository<Supplier>
    {
        Supplier? GetById(Guid id);
    }
}
