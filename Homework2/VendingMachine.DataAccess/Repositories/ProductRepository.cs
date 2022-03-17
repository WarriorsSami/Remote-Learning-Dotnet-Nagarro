#nullable enable
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Entities;

namespace VendingMachine.DataAccess.Repositories
{
    internal class ProductRepository: IProductRepository
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
                },
                new()
                {
                    ColumnId = 7,
                    Name = "Coca Cola Zero",
                    Price = 10.0m,
                    Quantity = 1
                },
                new()
                {
                    ColumnId = 8,
                    Name = "Coca Cola Light",
                    Price = 1.5m,
                    Quantity = 0
                },
            });
        }
        #endregion
        
        public IEnumerable<Product> GetAll()
        {
            return Products;
        }
        
        public Product? GetById(int code)
        {
            var product = Products.FirstOrDefault(product => product.ColumnId == code);
            
            return product;
        }
        
        public void UpdateQuantity(int code, int quantity)
        {
            var product = Products.FirstOrDefault(p => p.ColumnId == code);
            if (product != null)
            {
                product.Quantity = quantity;
            }
        }
    }
}