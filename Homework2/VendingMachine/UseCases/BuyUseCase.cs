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
            var productCode = _buyView.AskForProductCode();

            var product = _productRepository.GetByCode(productCode);
            _productRepository.UpdateQuantity(productCode, product.Quantity - 1);
            
            _buyView.DisplayProduct(product);
        }
    }
}