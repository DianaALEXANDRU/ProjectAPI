using Core.Dtos;
using DataLayer;
using DataLayer.Dtos;
using DataLayer.Entities;
using DataLayer.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class StockService
    {

        private readonly UnitOfWork unitOfWork;

        public StockService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Stock> GetAll()
        {
            var results = unitOfWork.Stock.GetAll();

            return results;
        }

        public StockDto GetById(int stockId)
        {
            var stock = unitOfWork.Stock.GetById(stockId);

            var result = stock.ToStockDto();

            return result;
        }

        public StockAddDto AddStock(StockAddDto payload)
        {
            if (payload == null) return null;


            var newStock = new Stock
            {
                Quantity = payload.Quantity,
                Price = payload.Price,
                ProductId = payload.ProductId,
              
            };

            unitOfWork.Stock.Insert(newStock);
            unitOfWork.SaveChanges();

            return payload;
        }


    }
}
