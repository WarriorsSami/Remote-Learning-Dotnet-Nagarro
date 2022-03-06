using System.Collections.Generic;
using VendingMachine.DataAccess.Models;

namespace VendingMachine.Domain.Presentation.IViews
{
    public interface IShelfView
    {
        void DisplayProducts(IEnumerable<Product> products);
    }
}