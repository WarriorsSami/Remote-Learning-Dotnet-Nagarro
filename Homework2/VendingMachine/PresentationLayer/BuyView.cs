using System;
using VendingMachine.Models;

namespace VendingMachine.PresentationLayer
{
    internal class BuyView: DisplayBase
    {
        public void DisplayProduct(Product product)
        {
            DisplayLine("You have bought the following product:", ConsoleColor.Cyan);
            DisplayLine($"{product.Name} - price: {product.Price}$, " +
                        $"colId: {product.ColumnId}, qty: {product.Quantity}",
                        ConsoleColor.Green);
        }
    }
}