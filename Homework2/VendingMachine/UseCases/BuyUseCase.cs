using System;
using VendingMachine.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.PresentationLayer;
using VendingMachine.Repositories;

namespace VendingMachine.UseCases
{
    internal class BuyUseCase: IUseCase
    {
        private readonly IVendingMachineApplication _application;
        private readonly IBuyView _buyView;
        private readonly IProductRepository _productRepository;
        
        public string Name => "buy";
        public string Description => "Buy a product";
        public bool CanExecute => !_application.UserIsLoggedIn;
        
        public BuyUseCase(
            IVendingMachineApplication application, 
            IBuyView buyView, IProductRepository productRepository)
        {
            _application = application;
            _buyView = buyView;
            _productRepository = productRepository;
        }
         
        public void Execute()
        {
            var productCodeStr = _buyView.AskForProductCode();
            if (string.IsNullOrWhiteSpace(productCodeStr))
            {
                throw new CancelOrderException("Order cancelled");
            }
            
            var productCode = int.Parse(productCodeStr);
            var product = _productRepository.GetByCode(productCode);
            if (product == null)
            {
                throw new ProductNotFoundException("Unavailable product");
            }
            if (product.Quantity == 0)
            {
                throw new ProductOutOfStockException("Product out of stock");
            }
            
            _productRepository.UpdateQuantity(productCode, product.Quantity - 1);
            
            _buyView.DisplayProduct(product);
        }
    }
}