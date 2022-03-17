using System;
using System.Collections.Generic;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Presentation.Views
{
    internal class ShelfView: IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            DisplayBase.DisplayLine("Available Products: ", ConsoleColor.Green);
            foreach (var item in products)
            {
                DisplayBase.DisplayLine($"{item.Name} - price: {item.Price}$, " +
                                  $"colId: {item.ColumnId}, qty: {item.Quantity}",
                                  ConsoleColor.Green);
            }
        }
    }
}