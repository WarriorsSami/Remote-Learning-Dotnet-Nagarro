using System;
using System.Collections.Generic;
using VendingMachine.DataAccess.Models;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Presentation.Views
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