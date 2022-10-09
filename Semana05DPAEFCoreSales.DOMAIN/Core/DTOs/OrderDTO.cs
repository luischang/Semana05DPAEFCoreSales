using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana05DPAEFCoreSales.DOMAIN.Core.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string? OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }
    }

    public class OrderNumberAmountDTO
    {
        public string? OrderNumber { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
