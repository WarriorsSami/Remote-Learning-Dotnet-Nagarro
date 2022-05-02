using System;
using VendingMachine.Business.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Dtos;
using VendingMachine.Domain.Presentation.ICommands;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Business.UseCases;

internal class BuyUseCase : IUseCase
{
    private readonly IBuyView _buyView;
    private readonly IProductRepository _productRepository;
    private readonly IPayCommand _payCommand;

    public BuyUseCase(
        IBuyView buyView,
        IProductRepository productRepository,
        IPayCommand payCommand
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
            _productRepository.UpdateQuantity(
                new QuantitySupply { ColumnId = productCode, Quantity = product.Quantity - 1 }
            );

            _buyView.DisplayProduct(product);
        }
    }
}
