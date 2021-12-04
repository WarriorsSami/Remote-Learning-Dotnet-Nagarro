using System;
using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.PresentationLayer
{
    public class ShelfView: DisplayBase
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            DisplayLine("Available Products: ", ConsoleColor.Green);
            foreach (var item in products)
            {
                DisplayLine($"{item.Name} - price: {item.Price}$, " +
                                  $"colId: {item.ColumnId}, qty: {item.Quantity}",
                                  ConsoleColor.Green);
            }
        }
    }
}