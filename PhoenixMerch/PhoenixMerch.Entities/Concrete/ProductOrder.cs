using PhoenixMerch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixMerch.Entities.Concrete
{
    public class ProductOrder : IEntity
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
