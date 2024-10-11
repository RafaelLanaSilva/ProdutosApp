using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Domain.Models.Entities
{
    public class Supplier
    {
        #region Properties

        public Guid? Id { get; set; }
        public string? Name { get; set; }

        #endregion

        #region Relationship
        public List<Product>? Products { get; set; }

        #endregion
    }
}
