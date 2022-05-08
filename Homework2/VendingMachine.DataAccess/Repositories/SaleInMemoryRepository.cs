using System.Collections.Generic;
using System.Linq;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Dtos;
using VendingMachine.Domain.Entities;

namespace VendingMachine.DataAccess.Repositories;

internal class SaleInMemoryRepository : ISaleRepository
{
    private static readonly List<Sale> Sales = new();

    public IEnumerable<Sale> Get(TimeInterval timeInterval)
    {
        return Sales.Where(s => s.Date >= timeInterval.Start && s.Date <= timeInterval.End);
    }

    public IEnumerable<ProductSale> GetGroupedByProduct(TimeInterval timeInterval)
    {
        return Sales
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
        Sales.Add(sale);
    }
}
