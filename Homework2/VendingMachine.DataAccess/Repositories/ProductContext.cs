using Microsoft.EntityFrameworkCore;
using VendingMachine.Business.Models;

namespace VendingMachine.DataAccess.Repositories
{
    internal class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        
        public DbSet<Product> Products { get; set; }
    }
}