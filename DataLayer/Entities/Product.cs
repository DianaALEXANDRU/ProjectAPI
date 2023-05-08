using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection.Emit;

namespace DataLayer.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName {  get; set; }
        public string Supplier { get; set; }

        public string Strenght { get; set; }
        public string PackingSize { get; set; }

        public string Unit { get; set; }
    }
}
