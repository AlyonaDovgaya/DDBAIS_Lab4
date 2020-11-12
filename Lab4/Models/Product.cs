using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Storage { get; set; }
        public string Packaging { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
