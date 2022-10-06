using System;
using System.Collections.Generic;
using VendingMachine.Domain.Business.IHelpersPayment;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Presentation.Views;

internal class BuyView : IBuyView
{
    public void DisplayProduct(Product product)
    {
        DisplayBase.DisplayLine("You have bought the following product:", ConsoleColor.Cyan);
        DisplayBase.DisplayLine(product.ToString(), ConsoleColor.Green);
    }

    public string AskForProductCode()
    {
        DisplayBase.DisplayLine("Enter the id for the product you wanna buy:", ConsoleColor.Yellow);
        var productCode = Console.ReadLine() ?? string.Empty;

        return productCode;
    }

    private static void DisplayPaymentMethods(IEnumerable<IPaymentMethod> paymentMethods)
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
