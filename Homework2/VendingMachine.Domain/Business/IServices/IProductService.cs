using System.Collections.Generic;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Domain.Business.IServices;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
}