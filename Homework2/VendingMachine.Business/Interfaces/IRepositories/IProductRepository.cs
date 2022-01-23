using System.Collections.Generic;
using VendingMachine.Business.Models;

namespace VendingMachine.Business.Interfaces.IRepositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int code);
        void UpdateQuantity(int code, int quantity);
    }
}