using System.Collections.Generic;
using System.Linq;
using VendingMachine.DataAccess.Contexts;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Dtos;
using VendingMachine.Domain.Entities;

namespace VendingMachine.DataAccess.Repositories;

internal class SalePersistentRepository : ISaleRepository
{
    private readonly SaleContext _context;

    public SalePersistentRepository(SaleContext context)
    {
        _context = context;
    }

    public IEnumerable<Sale> Get(TimeInterval timeInterval)
    {
        return _context.Sales.Where(
            s => s.Date >= timeInterval.Start && s.Date <= timeInterval.End
        );
    }

    public IEnumerable<ProductSale> GetGroupedByProduct(TimeInterval timeInterval)
    {
        return _context.Sales
            .Where(sale => sale.Date >= timeInterval.Start && sale.Date <= timeInterval.End)
            .GroupBy(sale => sale.ProductName)
            .Select(
                g =>
                    new ProductSale
                    {
                        Name = g.Key,
                        Quantity = g.Count(s => s.ProductName == g.Key)
                    }
            );
    }

    public void Add(Sale sale)
    {
        _context.Sales.Add(sale);
        _context.SaveChanges();
    }
}
