using System;
using System.Collections.Generic;
using VendingMachine.Business.Interfaces.IPresentationLayer;
using VendingMachine.Business.Models;

namespace VendingMachine.Presentation.PresentationLayer
{
    internal class ShelfView: DisplayBase, IShelfView
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