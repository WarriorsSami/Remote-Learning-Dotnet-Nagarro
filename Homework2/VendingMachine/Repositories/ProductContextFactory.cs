using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VendingMachine.Repositories
{
    internal class ProductContextFactory: IDesignTimeDbContextFactory<ProductContext>
    {
        public ProductContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build(); 
            var connectionString = configuration.GetConnectionString("DefaultConnection");
                        
            var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ProductContext(optionsBuilder.Options);
        }
    }
}