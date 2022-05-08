using System.Collections.Generic;
using VendingMachine.Domain.Dtos;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Domain.DataAccess.IRepositories;

public interface ISaleRepository
{
    IEnumerable<Sale> Get(TimeInterval timeInterval);
    IEnumerable<ProductSale> GetGroupedByProduct(TimeInterval timeInterval);
    void Add(Sale sale);
}