using System;

namespace VendingMachine.Domain.Dtos;

[Serializable]
public class ProductSale
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}