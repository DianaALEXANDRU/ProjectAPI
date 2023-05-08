using DataLayer.Repositories;

namespace DataLayer
{
    public class UnitOfWork
    {
       

        public UserRepository Users { get; }

        public RoleRepository Roles { get; }

        public ProductRepository Products { get; }

        private readonly AppDbContext _dbContext;

        public UnitOfWork
        (
            AppDbContext dbContext,
         
            UserRepository users,
            RoleRepository roles,
            ProductRepository products
        )
        {
            _dbContext = dbContext;
           
            Users = users;
            Roles = roles;
            Products = products;
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch(Exception exception)
            {
                var errorMessage = "Error when saving to the database: "
                    + $"{exception.Message}\n\n"
                    + $"{exception.InnerException}\n\n"
                    + $"{exception.StackTrace}\n\n";

                Console.WriteLine(errorMessage);
            }
        }
    }
}
