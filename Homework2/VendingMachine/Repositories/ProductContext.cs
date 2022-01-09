using Microsoft.EntityFrameworkCore;
using VendingMachine.Models;

namespace VendingMachine.Repositories
{
    internal class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        
        public DbSet<Product> Products { get; set; }
    }
}