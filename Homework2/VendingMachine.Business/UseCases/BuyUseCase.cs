using System;
using System.Runtime.CompilerServices;
using VendingMachine.Business.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Presentation;
using VendingMachine.Domain.Presentation.IViews;

[assembly: InternalsVisibleTo("VendingMachine.Test")]
[assembly: InternalsVisibleTo("VendingMachine")]

namespace VendingMachine.Business.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IBuyView _buyView;
        private readonly IProductRepository _productRepository;
        private readonly ICommand _payCommand;

        public BuyUseCase(
            IBuyView buyView,
            IProductRepository productRepository,
            ICommand payCommand
        )
        {
            _buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            _productRepository =
                productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _payCommand = payCommand ?? throw new ArgumentNullException(nameof(payCommand));
        }

        public void Execute(params object[] args)
        {
            var productCodeStr = _buyView.AskForProductCode();
            if (string.IsNullOrWhiteSpace(productCodeStr))
            {
                throw new CancelOrderException("Order cancelled due to empty product code");
            }

            var productCode = int.Parse(productCodeStr);
            if (_payCommand.CanExecute)
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

                _payCommand.Execute(product.Price);
                _productRepository.UpdateQuantity(productCode, product.Quantity - 1);

                _buyView.DisplayProduct(product);
            }
        }
    }
}
