using VendingMachine.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.Models;
using VendingMachine.Repositories;

namespace VendingMachine.Services
{
    public class BuyProductService
    {
        private readonly ProductRepository _productRepository;

        public BuyProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public Product BuyProduct(int productId)
        {
            var product = _productRepository.GetByCode(productId);
            if (product == null)
            {
                throw new ProductNotFoundException("Unavailable product");
            }
            if (product.Quantity == 0)
            {
                throw new ProductOutOfStockException("Product out of stock");
            }
            
            _productRepository.UpdateQuantity(productId, product.Quantity - 1);

            return product;
        }
    }
}