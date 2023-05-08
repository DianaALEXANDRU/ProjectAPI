using DataLayer.Dtos;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public static class ProductsMappingExtensions
    {
        public static List<ProductDto> ToProductDtos(this List<Product> products)
        {
            var results = products.Select(e => e.ToProductDto()).ToList();

            return results;
        }

        public static ProductDto ToProductDto(this Product product)
        {
            if (product == null) return null;

            var result = new ProductDto();
            result.Id = product.Id;
            result.ProductName = product.ProductName;
            result.Supplier= product.Supplier;
            result.Strenght = product.Strenght; 
            result.PackingSize = product.PackingSize;
            result.Unit= product.Unit;

            return result;
        }
    }
}
