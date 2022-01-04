using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Interfaces.IRepositories
{
    internal interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int code);
        void UpdateQuantity(int code, int quantity);
    }
}