using System;
using VendingMachine.Business.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Business.UseCases;

internal class SupplyExistingProductUseCase : IUseCase
{
    private readonly ISupplyProductView _supplyView;
    private readonly IProductRepository _productRepository;

    public SupplyExistingProductUseCase(
        IProductRepository productRepository,
        ISupplyProductView supplyView
    )
    {
        _productRepository =
            productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _supplyView = supplyView ?? throw new ArgumentNullException(nameof(supplyView));
    }

    public void Execute(params object[] args)
    {
        var quantitySupply = _supplyView.RequestProductQuantity();
        if (quantitySupply.Quantity <= 0)
        {
            throw new CancelOrderException("Order cancelled due to invalid quantity");
        }

        _productRepository.IncreaseQuantity(quantitySupply);

        var product = _productRepository.GetById(quantitySupply.ColumnId);
        if (product == null)
        {
            throw new ProductNotFoundException("Unavailable product");
        }

        _supplyView.DisplayProduct(product);
    }
}
