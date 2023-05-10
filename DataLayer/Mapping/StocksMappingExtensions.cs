using DataLayer.Dtos;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public static class StocksMappingExtensions
    {
        public static List<StockDto> ToStockDtos(this List<Stock> stocks)
        {
            var result = stocks.Select(e => e.ToStockDto()).ToList();
            return result;
        }

        public static StockDto ToStockDto(this Stock stock)
        {
            if (stock == null) return null;

            var result = new StockDto();
            result.Id = stock.Id;
            result.ProductId = stock.ProductId;
            result.Quantity = stock.Quantity;
            result.Price = stock.Price;
            result.Product = stock.Product;
            return result;
            
        }


    }
}
