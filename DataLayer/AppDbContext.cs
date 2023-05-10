using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder
            //        .UseSqlServer("Server =.; Database = Proiect; Trusted_Connection = True; TrustServerCertificate = True", b => b.MigrationsAssembly("Project"))
            optionsBuilder
                  .UseSqlServer("Server=localhost;Database=Proiect;User Id=admin;Password=1q2w3e;")
                  .LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          //  modelBuilder.Entity<Class>().Property(e => e.Name).HasMaxLength(10);
        }

     
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
