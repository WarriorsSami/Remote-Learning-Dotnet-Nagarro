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
        
        private readonly IPaymentUseCase _paymentUseCase;
        
        public string Name => "buy";
        public string Description => "Buy a product | " + _paymentUseCase.Description;
        public bool CanExecute => !_application.UserIsLoggedIn;
        
        public BuyUseCase(
            IVendingMachineApplication application, 
            IBuyView buyView,
            IProductRepository productRepository,
            IPaymentUseCase paymentUseCase)
        {
            _application = application;
            _buyView = buyView;
            _productRepository = productRepository;
            _paymentUseCase = paymentUseCase;
        }
         
        public void Execute()
        {
            var productCodeStr = _buyView.AskForProductCode();
            if (string.IsNullOrWhiteSpace(productCodeStr))
            {
                throw new CancelOrderException("Order cancelled due to empty product code");
            }
            
            var productCode = int.Parse(productCodeStr);
            if (_paymentUseCase.CanExecute)
            {
                var product = _productRepository.GetById(productCode);
                if (product == null)
                {
                    throw new ProductNotFoundException("Unavailable product");
                }

                if (product.Quantity == 0)
                {
                    throw new ProductOutOfStockException("Product out of stock");
                }
    
                _paymentUseCase.Execute(product.Price);
                _productRepository.UpdateQuantity(productCode, product.Quantity - 1);

                _buyView.DisplayProduct(product);
            }
        }
    }
}