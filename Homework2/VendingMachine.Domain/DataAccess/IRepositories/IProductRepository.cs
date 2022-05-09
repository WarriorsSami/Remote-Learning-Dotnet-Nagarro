using System.Collections.Generic;
using VendingMachine.Domain.Dtos;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Domain.DataAccess.IRepositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product GetById(int code);
    void AddOrReplace(Product product);
    void Delete(int code);
    void UpdateQuantity(QuantitySupply quantitySupply);
    void IncreaseQuantity(QuantitySupply quantitySupply);
}
