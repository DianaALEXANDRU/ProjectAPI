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
        long Quantity { get; set; }
        double Price { get; set; }

        public int ProductId { get; set; }
    }
}
