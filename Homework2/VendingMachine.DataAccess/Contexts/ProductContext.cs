using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VendingMachine.Domain.Entities;

namespace VendingMachine.DataAccess.Contexts;

internal class ProductContext : DbContext
{
    public ProductContext() { }

    public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}

internal class ProductContextFactory : IDesignTimeDbContextFactory<ProductContext>
{
    public ProductContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
        optionsBuilder.UseNpgsql(args[0]);

        return new ProductContext(optionsBuilder.Options);
    }
}
