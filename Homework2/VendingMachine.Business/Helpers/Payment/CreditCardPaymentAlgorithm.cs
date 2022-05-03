using VendingMachine.Business.CustomExceptions.PaymentUseCaseExceptions;
using VendingMachine.Domain.Business.IHelpersPayment;
using VendingMachine.Domain.Presentation.IViews.IPaymentTerminals;

namespace VendingMachine.Business.Helpers.Payment
{
    public class CreditCardPaymentAlgorithm : IPaymentAlgorithm
    {
        public PaymentMethodType Id => PaymentMethodType.CreditCard;
        public string Name => "Credit Card";
        public string Command => "Please insert your credit card credentials!";

        private readonly ICardTerminal _terminal;
        private readonly ICardValidityAlgorithm _validityAlgorithm;

        public CreditCardPaymentAlgorithm(
            ICardTerminal terminal,
            ICardValidityAlgorithm validityAlgorithm
        )
        {
            _terminal = terminal;
            _validityAlgorithm = validityAlgorithm;
        }

        public void Run(decimal price)
        {
            var creditCardNumber = _terminal.AskForCardNumber();
            if (!_validityAlgorithm.IsValid(creditCardNumber))
            {
                throw new InvalidCreditCardIdException("Credit card's credentials are corrupted");
            }
        }
    }
}
