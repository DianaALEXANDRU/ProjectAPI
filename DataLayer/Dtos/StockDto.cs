using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos
{
    public class StockDto
    {
        public int Id { get; set; }
        public long Quantity { get; set; }
        public double Price { get; set; }

        public int ProductId { get; set; }
    }
}
