﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using VendingMachine.Business.Helpers.Payment;
using VendingMachine.DataAccess.Models;
using VendingMachine.Domain.Presentation.IViews;

[assembly: InternalsVisibleTo("VendingMachine")]
namespace VendingMachine.Presentation.Views
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
            var productCode = Console.ReadLine() ?? string.Empty;

            return productCode;
        }

        private void DisplayPaymentMethods(IEnumerable<PaymentMethod> paymentMethods)
        {
            foreach (var paymentMethod in paymentMethods)
            {
                DisplayLine($"{(int)paymentMethod.Id} - {paymentMethod.Name}", ConsoleColor.Green);
            }
        }

        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods)
        {
            DisplayLine("Please select a payment method:", ConsoleColor.Yellow);
            DisplayPaymentMethods(paymentMethods);
            
            var paymentMethodId = int.Parse(Console.ReadLine() ?? "0");
            return paymentMethodId;
        }

        public void DisplayCommand(string command)
        {
            DisplayLine(command, ConsoleColor.Magenta);
        }
    }
}