using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class UpdateStockDto
    {
        public int Id { get; set; }

        public long Quantity { get; set; }

        public double Price { get; set; }

        public int ProductId { get; set; }
    }
}
