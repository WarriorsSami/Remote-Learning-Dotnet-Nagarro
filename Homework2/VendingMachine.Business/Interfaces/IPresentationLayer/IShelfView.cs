using System.Collections.Generic;
using VendingMachine.Business.Models;

namespace VendingMachine.Business.Interfaces.IPresentationLayer
{
    public interface IShelfView
    {
        void DisplayProducts(IEnumerable<Product> products);
    }
}