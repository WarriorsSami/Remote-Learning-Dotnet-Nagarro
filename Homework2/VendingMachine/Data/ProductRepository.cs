using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models;

namespace VendingMachine.Data
{
    internal class ProductRepository
    {
        private static readonly List<Product> Products = new();
        
        #region ProductRepository Constructor
        public ProductRepository()
        {
            if (Products.Count != 0) return;
            
            Products.AddRange(new Product[]
            {
                new()
                {
                    ColumnId = 1,
                    Name = "Coca Cola",
                    Price = 1.5m,
                    Quantity = 10
                },
                new()
                {
                    ColumnId = 2,
                    Name = "Fanta",
                    Price = 1.5m,
                    Quantity = 10
                },
                new()
                {
                    ColumnId = 3,
                    Name = "Sprite",
                    Price = 1.5m,
                    Quantity = 10
                },
                new()
                {
                    ColumnId = 4,
                    Name = "Pepsi",
                    Price = 1.5m,
                    Quantity = 10
                },
                new()
                {
                    ColumnId = 5,
                    Name = "7up",
                    Price = 1.5m,
                    Quantity = 10
                },
                new()
                {
                    ColumnId = 6,
                    Name = "Fanta Light",
                    Price = 1.5m,
                    Quantity = 10
                }
            });
        }
        #endregion
        
        public IEnumerable<Product> GetAll()
        {
            return Products;
        }
    }
}