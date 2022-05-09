using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Entities;

namespace VendingMachine.WebServices.Services;

internal class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository =
            productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _productRepository.GetAll();
    }

    public Product GetProductById(int id)
    {
        return _productRepository.GetById(id);
    }

    public void AddProduct(Product product)
    {
        _productRepository.AddOrReplace(product);
    }

    public void UpdateProduct(Product product)
    {
        _productRepository.AddOrReplace(product);
    }

    public void DeleteProduct(int id)
    {
        _productRepository.Delete(id);
    }
}
