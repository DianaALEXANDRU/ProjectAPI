using Core.Dtos;
using DataLayer;
using DataLayer.Dtos;
using DataLayer.Entities;
using DataLayer.Mapping;
using DataLayer.Repositories;
using Microsoft.IdentityModel.Tokens;
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
        private ProductRepository productRepository;

        public StockService(UnitOfWork unitOfWork, ProductRepository productRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
        }

        public List<Stock> GetAll()
        {
            var results = unitOfWork.Stock.GetAll();
    
            for (int idx= 0; idx< results.Count(); ++idx)
            {
                results[idx].Product = productRepository.GetById(results[idx].ProductId);
            }

            return results;
        }

        public StockDto GetById(int stockId)
        {
            var stock = unitOfWork.Stock.GetById(stockId);


            var result = stock.ToStockDto();
            result.Product = productRepository.GetById(result.ProductId);

            return result;
        }

        public StockAddDto AddStock(StockAddDto payload)
        {
            if (payload == null) return null;


            var existingProduct = unitOfWork.Products.GetById(payload.ProductId);
            if (existingProduct == null) return null;


            var newStock = new Stock
            {
                Quantity = payload.Quantity,
                Price = payload.Price,
                ProductId = payload.ProductId,
                Product = existingProduct,

            };

            unitOfWork.Stock.Insert(newStock);
            unitOfWork.SaveChanges();

            return payload;
        }

        public bool DeleteById(int stockId)
        {
            var stock = unitOfWork.Stock.GetById(stockId);

            if (stock == null)
            {
                return false;
            }


            unitOfWork.Stock.Remove(stock);
            unitOfWork.SaveChanges();

            return true;

        }

        public bool UpdateStock(UpdateStockDto updateStockDto)
        {

            var stock = unitOfWork.Stock.GetById(updateStockDto.Id);

            if (stock == null)
            {
                return false;
            }

            if ( updateStockDto.Price >=0 )
            {
                stock.Price = updateStockDto.Price;
            }
            if (updateStockDto.Quantity >= 0)
            {
                stock.Quantity = updateStockDto.Quantity;
            }
           
            if(unitOfWork.Products.GetById(updateStockDto.ProductId) != null)
               stock.ProductId = updateStockDto.ProductId;
            



            unitOfWork.Stock.Update(stock);
            unitOfWork.SaveChanges();
            return true;
        }

    }
}
