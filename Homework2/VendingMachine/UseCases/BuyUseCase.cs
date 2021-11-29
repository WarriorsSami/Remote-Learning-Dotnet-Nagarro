using System;
using VendingMachine.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.Data;
using VendingMachine.PresentationLayer;

namespace VendingMachine.UseCases
{
    internal class BuyUseCase: IUseCase
    {
        private readonly VendingMachineApplication _application;
        private readonly BuyView _buyView;
        private readonly ProductRepository _productRepository;

        public string Name => "buy";
        public string Description => "Buy a product";
        public bool CanExecute => !_application.UserIsLoggedIn;
        
        public BuyUseCase(
            VendingMachineApplication application, 
            BuyView buyView, 
            ProductRepository productRepository)
        {
            _application = application ?? throw new ArgumentNullException(nameof(application));
            _buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
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