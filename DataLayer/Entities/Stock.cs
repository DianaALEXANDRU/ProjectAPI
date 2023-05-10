using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Stock : BaseEntity
    {
        long Quantity {  get; set; }
        double Price { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
