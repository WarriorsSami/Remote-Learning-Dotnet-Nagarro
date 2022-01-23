using System;
using VendingMachine.Business.Interfaces.IHelpersPayment;

namespace VendingMachine.Business.Helpers.Payment
{
    public class CreditCardPaymentTerminal: ICardTerminal
    {
        public string AskForCardNumber()
        {
            var creditCardNumber = Console.ReadLine() ?? string.Empty;
            return creditCardNumber;
        }
    }
}