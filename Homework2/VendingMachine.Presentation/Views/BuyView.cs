using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using VendingMachine.Domain.Business.IHelpersPayment;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Presentation.IViews;

[assembly: InternalsVisibleTo("VendingMachine")]

namespace VendingMachine.Presentation.Views
{
    internal class BuyView : IBuyView
    {
        public void DisplayProduct(Product product)
        {
            DisplayBase.DisplayLine("You have bought the following product:", ConsoleColor.Cyan);
            DisplayBase.DisplayLine(
                $"{product.Name} - price: {product.Price}$, "
                    + $"colId: {product.ColumnId}, qty: {product.Quantity}",
                ConsoleColor.Green
            );
        }

        public string AskForProductCode()
        {
            DisplayBase.DisplayLine("Please enter the product code:", ConsoleColor.Yellow);
            var productCode = Console.ReadLine() ?? string.Empty;

            return productCode;
        }

        private void DisplayPaymentMethods(IEnumerable<IPaymentMethod> paymentMethods)
        {
            foreach (var paymentMethod in paymentMethods)
            {
                DisplayBase.DisplayLine(
                    $"{(int)paymentMethod.Id} - {paymentMethod.Name}",
                    ConsoleColor.Green
                );
            }
        }

        public int AskForPaymentMethod(IEnumerable<IPaymentMethod> paymentMethods)
        {
            DisplayBase.DisplayLine("Please select a payment method:", ConsoleColor.Yellow);
            DisplayPaymentMethods(paymentMethods);

            var paymentMethodId = int.Parse(Console.ReadLine() ?? "0");
            return paymentMethodId;
        }

        public void DisplayCommand(string command)
        {
            DisplayBase.DisplayLine(command, ConsoleColor.Magenta);
        }
    }
}
