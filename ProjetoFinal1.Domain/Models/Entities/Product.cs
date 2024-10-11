using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Domain.Models.Entities
{
    public class Product
    {

        #region Properties

        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        public Guid? SupplierId { get; set; }

        #endregion

        #region Relationship

        public Supplier? Supplier { get; set; }

        #endregion

    }
}
