using System;
using VendingMachine.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.Models;

namespace VendingMachine.PresentationLayer
{
    internal class BuyView: DisplayBase, IBuyView
    {
        public void DisplayProduct(Product product)
        {
            DisplayLine("You have bought the following product:", ConsoleColor.Cyan);
            DisplayLine($"{product.Name} - price: {product.Price}$, " +
                        $"colId: {product.ColumnId}, qty: {product.Quantity}",
                        ConsoleColor.Green);
        }

        public string AskForProductCode()
        {
            DisplayLine("Please enter the product code:", ConsoleColor.Yellow);
            var productCode = Console.ReadLine() ?? "";

            return productCode;
        }
    }
}