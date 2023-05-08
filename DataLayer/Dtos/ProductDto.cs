using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Supplier { get; set; }

        public string Strenght { get; set; }
        public string PackingSize { get; set; }

        public string Unit { get; set; }
    }
}
