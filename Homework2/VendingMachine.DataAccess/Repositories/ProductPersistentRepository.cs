using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VendingMachine.DataAccess.Contexts;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Dtos;
using VendingMachine.Domain.Entities;

namespace VendingMachine.DataAccess.Repositories;

internal class ProductPersistentRepository : IProductRepository
{
    private readonly ProductContext _context;

    public ProductPersistentRepository(ProductContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product GetById(int code)
    {
        return _context.Products.FirstOrDefault(p => p.ColumnId == code);
    }

    public void UpdateQuantity(QuantitySupply quantitySupply)
    {
        var product = _context.Products.FirstOrDefault(p => p.ColumnId == quantitySupply.ColumnId);
        if (product != null)
        {
            product.Quantity = quantitySupply.Quantity;
            _context.SaveChanges();
        }
    }

    public void IncreaseQuantity(QuantitySupply quantitySupply)
    {
        var product = _context.Products.FirstOrDefault(p => p.ColumnId == quantitySupply.ColumnId);
        if (product != null)
        {
            product.Quantity += quantitySupply.Quantity;
            _context.SaveChanges();
        }
    }

    public void AddOrReplace(Product product)
    {
        var existingProduct = _context.Products.FirstOrDefault(p => p.ColumnId == product.ColumnId);
        
        if (existingProduct != null)
        {
            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            _context.SaveChanges();
        }
        else
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
