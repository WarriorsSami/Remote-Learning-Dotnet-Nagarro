using System.Collections.Generic;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Domain.Presentation.IViews;

public interface IShelfView
{
    void DisplayProducts(IEnumerable<Product> products);
}