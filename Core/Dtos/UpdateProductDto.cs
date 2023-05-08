using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class UpdateProductDto
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(100)]
        public string ProductName { get; set; }

        [MaxLength(100)]
        public string Supplier { get; set; }

        [MaxLength(100)]
        public string Strength { get; set; }

        [MaxLength(20)]
        public string PackingSize { get; set; }

        [MaxLength(2)]
        public string Unit { get; set; }
    }
}
