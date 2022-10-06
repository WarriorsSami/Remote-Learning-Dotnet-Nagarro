using System;
using VendingMachine.Domain.Presentation.IViews.IPaymentTerminals;

namespace VendingMachine.Presentation.Views.PaymentTerminals;

public class CreditCardPaymentTerminal : ICardTerminal
{
    public string AskForCardNumber()
    {
        var creditCardNumber = Console.ReadLine() ?? string.Empty;
        return creditCardNumber;
    }
}
