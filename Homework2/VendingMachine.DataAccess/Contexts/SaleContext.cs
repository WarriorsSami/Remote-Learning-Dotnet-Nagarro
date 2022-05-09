using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VendingMachine.Domain.Entities;

namespace VendingMachine.DataAccess.Contexts;

internal class SaleContext : DbContext
{
    public SaleContext() { }

    public SaleContext(DbContextOptions<SaleContext> options) : base(options) { }

    public DbSet<Sale> Sales { get; set; }
}

internal class SaleContextFactory : IDesignTimeDbContextFactory<SaleContext>
{
    public SaleContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SaleContext>();
        optionsBuilder.UseNpgsql(args[0]);

        return new SaleContext(optionsBuilder.Options);
    }
}
