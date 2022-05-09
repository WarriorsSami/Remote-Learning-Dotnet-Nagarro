using System.Collections.Generic;
using System.Linq;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Dtos;
using VendingMachine.Domain.Entities;

namespace VendingMachine.DataAccess.Repositories;

internal class ProductInMemoryRepository : IProductRepository
{
    private static readonly List<Product> Products = new();

    #region ProductRepository Constructor
    public ProductInMemoryRepository()
    {
        if (Products.Count != 0)
            return;

        Products.AddRange(
            new Product[]
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
            }
        );
    }
    #endregion

    public IEnumerable<Product> GetAll()
    {
        return Products;
    }

    public Product GetById(int code)
    {
        var product = Products.FirstOrDefault(product => product.ColumnId == code);

        return product;
    }

    public void Delete(int code)
    {
        Products.Remove(GetById(code));
    }

    public void UpdateQuantity(QuantitySupply quantitySupply)
    {
        var product = Products.FirstOrDefault(p => p.ColumnId == quantitySupply.ColumnId);
        if (product != null)
        {
            product.Quantity = quantitySupply.Quantity;
        }
    }

    public void IncreaseQuantity(QuantitySupply quantitySupply)
    {
        var product = Products.FirstOrDefault(p => p.ColumnId == quantitySupply.ColumnId);
        if (product != null)
        {
            product.Quantity += quantitySupply.Quantity;
        }
    }

    public void AddOrReplace(Product product)
    {
        var productToUpdate = Products.FirstOrDefault(p => p.ColumnId == product.ColumnId);
        if (productToUpdate != null)
        {
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Quantity = product.Quantity;
        }
        else
        {
            Products.Add(product);
        }
    }
}
