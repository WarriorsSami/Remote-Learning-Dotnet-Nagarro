using VendingMachine.Domain.Entities;

namespace VendingMachine.Domain.Presentation.IViews;

public interface IDisplayView
{
   void DisplayProduct(Product product);
}