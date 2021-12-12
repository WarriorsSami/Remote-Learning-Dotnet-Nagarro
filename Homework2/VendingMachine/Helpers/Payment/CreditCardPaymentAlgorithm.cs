using System;

namespace VendingMachine.Helpers.Payment
{
    internal class CreditCardPaymentAlgorithm: IPaymentAlgorithm
    {
        public PaymentMethodType Id => PaymentMethodType.CreditCard;
        public string Name => "Credit Card";
        
        private readonly CreditCardPaymentTerminal _terminal;

        public CreditCardPaymentAlgorithm(CreditCardPaymentTerminal terminal)
        {
            _terminal = terminal;
        }

        public void Run(decimal price)
        {
            Console.WriteLine("Please insert your credit card number");
        }
    }
}