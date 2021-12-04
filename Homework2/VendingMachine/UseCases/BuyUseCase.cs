using System;
using VendingMachine.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.PresentationLayer;
using VendingMachine.Services;

namespace VendingMachine.UseCases
{
    public class BuyUseCase: IUseCase
    {
        private readonly VendingMachineApplication _application;
        private readonly BuyView _buyView;
        private readonly BuyProductService _buyProductService;
        
        public string Name => "buy";
        public string Description => "Buy a product";
        public bool CanExecute => !_application.UserIsLoggedIn;
        
        public BuyUseCase(
            VendingMachineApplication application, 
            BuyView buyView,
            BuyProductService buyProductService)
        {
            _application = application ?? throw new ArgumentNullException(nameof(application));
            _buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            _buyProductService = buyProductService ?? throw new ArgumentNullException(nameof(buyProductService));
        }
         
        public void Execute()
        {
            var productCodeStr = _buyView.AskForProductCode();
            if (string.IsNullOrWhiteSpace(productCodeStr))
            {
                throw new CancelOrderException("Order cancelled");
            }
            
            var productCode = int.Parse(productCodeStr);
            var product = _buyProductService.BuyProduct(productCode);
            
            _buyView.DisplayProduct(product);
        }
    }
}