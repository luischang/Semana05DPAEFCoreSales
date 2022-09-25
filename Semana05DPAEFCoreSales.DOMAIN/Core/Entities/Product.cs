using System;
using System.Collections.Generic;

namespace Semana05DPAEFCoreSales.DOMAIN.Core.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public int SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? Package { get; set; }
        public bool IsDiscontinued { get; set; }

        public virtual Supplier Supplier { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
