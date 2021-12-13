using System;

namespace VendingMachine.Helpers.Payment
{
    internal class CreditCardPaymentTerminal
    {
        public string AskForCardNumber()
        {
            var creditCardNumber = Console.ReadLine() ?? string.Empty;
            return creditCardNumber;
        }
    }
}