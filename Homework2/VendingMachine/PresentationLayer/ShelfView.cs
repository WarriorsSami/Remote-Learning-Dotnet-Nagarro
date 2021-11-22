using System;
using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.PresentationLayer
{
    internal class ShelfView: DisplayBase
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            Console.WriteLine("Available products:");
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Name} - price: {item.Price}$, " +
                                  $"colId: {item.ColumnId}, qty: {item.Quantity}");
            }
        }
    }
}