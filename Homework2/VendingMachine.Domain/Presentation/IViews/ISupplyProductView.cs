using VendingMachine.Domain.Dtos;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Domain.Presentation.IViews;

public interface ISupplyProductView: IDisplayView
{
    QuantitySupply RequestProductQuantity();
    Product RequestNewProduct();
}