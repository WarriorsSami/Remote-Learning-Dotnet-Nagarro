using System.Collections.Generic;
using System.Linq;
using VendingMachine.DataAccess.Contexts;
using VendingMachine.Domain.DataAccess.IRepositories;
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

    public void UpdateQuantity(int code, int quantity)
    {
        var product = _context.Products.FirstOrDefault(p => p.ColumnId == code);
        if (product != null)
        {
            product.Quantity = quantity;
            _context.SaveChanges();
        }
    }
}