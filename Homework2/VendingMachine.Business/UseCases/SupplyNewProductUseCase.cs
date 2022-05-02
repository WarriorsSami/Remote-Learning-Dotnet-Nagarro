using System;
using VendingMachine.Business.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Business.UseCases;

internal class SupplyNewProductUseCase : IUseCase
{
    private readonly ISupplyProductView _supplyView;
    private readonly IProductRepository _productRepository;

    public SupplyNewProductUseCase(
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
        var productToSupply = _supplyView.RequestNewProduct();
        if (string.IsNullOrWhiteSpace(productToSupply.Name))
        {
            throw new CancelOrderException("Order cancelled due to empty product name");
        }
        if (productToSupply.Quantity <= 0)
        {
            throw new CancelOrderException("Order cancelled due to invalid quantity");
        }
        if (productToSupply.Price <= 0)
        {
            throw new CancelOrderException("Order cancelled due to invalid price");
        }
        
        _productRepository.AddOrReplace(productToSupply);
        
        var productSupplied = _productRepository.GetById(productToSupply.ColumnId);
        if (productSupplied == null)
        {
            throw new ProductNotFoundException("Unable to supply product");
        }

        _supplyView.DisplayProduct(productSupplied);
    }
}
