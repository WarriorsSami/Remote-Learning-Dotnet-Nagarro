﻿using System.Collections.Generic;
using VendingMachine.DataAccess.Models;

namespace VendingMachine.Domain.DataAccess.IRepositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int code);
        void UpdateQuantity(int code, int quantity);
    }
}