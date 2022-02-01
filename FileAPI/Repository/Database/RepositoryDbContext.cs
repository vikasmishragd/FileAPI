using FileAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace FileAPI.Repository.Database
{
    public class RepositoryDbContext : DbContext
    {
       protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = ProductInformation");
        }
        public DbSet<Product> Products { get; set; }
    }
}
