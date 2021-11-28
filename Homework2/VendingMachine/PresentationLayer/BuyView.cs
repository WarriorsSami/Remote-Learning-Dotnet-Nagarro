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

        public int AskForProductCode()
        {
            DisplayLine("Please enter the product code:", ConsoleColor.Yellow);
            var productCode = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            return productCode;
        }
    }
}