using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class StockAddDto
    {
        [Required]
        public long Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
