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

    
    }
}
