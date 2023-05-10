using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class StockRepository : RepositoryBase<Stock>
    {
        private readonly AppDbContext dbContext;
        
        public StockRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
