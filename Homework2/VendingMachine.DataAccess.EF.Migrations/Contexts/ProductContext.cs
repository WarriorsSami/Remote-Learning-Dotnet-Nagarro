using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using VendingMachine.Domain.Entities;

[assembly:
    InternalsVisibleTo("VendingMachine"),
    InternalsVisibleTo("VendingMachine.DataAccess")
]

namespace VendingMachine.DataAccess.EF.Migrations.Contexts
{
    internal class ProductContext : DbContext
    {
        public ProductContext() { }
        
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
