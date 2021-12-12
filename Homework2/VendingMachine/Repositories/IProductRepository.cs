using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Repositories
{
    internal interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetByCode(int code);
        void UpdateQuantity(int code, int quantity);
    }
}