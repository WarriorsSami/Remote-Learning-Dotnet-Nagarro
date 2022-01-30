﻿using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using VendingMachine.DataAccess.Models;

[assembly: InternalsVisibleTo("VendingMachine")]
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