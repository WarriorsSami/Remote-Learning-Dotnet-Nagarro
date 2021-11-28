using System;
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
            _application = application;
            _buyView = buyView;
            _productRepository = productRepository;
        }
         
        public void Execute()
        {
            Console.WriteLine("Please enter the product code:");
            var productCode = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            
            var product = _productRepository.GetByCode(productCode) ?? throw new InvalidOperationException();
            _productRepository.UpdateQuantity(productCode, product.Quantity - 1);
            
            _buyView.DisplayProduct(product);
        }
    }
}