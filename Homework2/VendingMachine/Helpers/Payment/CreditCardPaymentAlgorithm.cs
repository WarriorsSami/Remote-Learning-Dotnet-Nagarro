using System;
using VendingMachine.CustomExceptions.PaymentUseCaseExceptions;

namespace VendingMachine.Helpers.Payment
{
    internal class CreditCardPaymentAlgorithm: IPaymentAlgorithm
    {
        public PaymentMethodType Id => PaymentMethodType.CreditCard;
        public string Name => "Credit Card";
        public string Command => "Please insert your credit card credentials!";
        
        private readonly CreditCardPaymentTerminal _terminal;

        public CreditCardPaymentAlgorithm(CreditCardPaymentTerminal terminal)
        {
            _terminal = terminal;
        }

        public void Run(decimal price)
        {
            var creditCardNumber = _terminal.AskForCardNumber();
            if (!CardChecker.IsValid(creditCardNumber))
            {
                throw new InvalidCardId("Credit card's credentials are corrupted");
            }
        }
    }
}