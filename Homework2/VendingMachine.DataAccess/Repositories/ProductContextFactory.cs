using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace VendingMachine.DataAccess.Repositories
{
    internal class ProductContextFactory: IDesignTimeDbContextFactory<ProductContext>
    {
        public ProductContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
                .Build(); 
            var connectionString = configuration.GetConnectionString("DefaultConnection");
                        
            var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ProductContext(optionsBuilder.Options);
        }
    }
}