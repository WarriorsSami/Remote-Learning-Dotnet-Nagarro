﻿using System;
using VendingMachine.Interfaces.IHelpersPayment;

namespace VendingMachine.Helpers.Payment
{
    internal class CreditCardPaymentTerminal: ICardTerminal
    {
        public string AskForCardNumber()
        {
            var creditCardNumber = Console.ReadLine() ?? string.Empty;
            return creditCardNumber;
        }
    }
}