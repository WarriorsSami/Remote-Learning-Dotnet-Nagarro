using Microsoft.EntityFrameworkCore;
using VendingMachine.Domain.Entities;

namespace VendingMachine.DataAccess.Contexts
{
    internal class ProductContext : DbContext
    {
        public ProductContext() { }
        
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
