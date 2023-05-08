using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class ProductAddDto
    {
        [Required, MaxLength(100)]
        public string ProductName { get; set; }

        [Required, MaxLength(100)]
        public string Supplier { get; set; }

        [Required, MaxLength(100)]
        public string Strenght { get; set; }

        [Required, MaxLength(20)]
        public string PackingSize { get; set; }

        [Required, MaxLength(2)]
        public string Unit { get; set; }
    }
}
