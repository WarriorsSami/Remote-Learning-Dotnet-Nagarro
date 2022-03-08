using System.Collections.Generic;
using System.Runtime.CompilerServices;
using VendingMachine.Domain.Business.IHelpersPayment;
using VendingMachine.Domain.Presentation.IViews.IPaymentTerminals;

[assembly: InternalsVisibleTo("VendingMachine")]
namespace VendingMachine.Business.Helpers.Payment
{
    internal class PaymentFactory: IPaymentFactory
    {
        private static readonly List<PaymentMethod> PaymentMethods = new();
        private static readonly List<IPaymentAlgorithm> PaymentAlgorithms = new();

        public PaymentFactory(
            ICashTerminal cashTerminal,
            ICardTerminal creditCardTerminal) 
        {
            if (PaymentMethods.Count == 0)
            {
                PaymentMethods.AddRange(new List<PaymentMethod>
                {
                    new(PaymentMethodType.Cash, "Cash"), 
                    new(PaymentMethodType.CreditCard, "Credit Card")
                });
            }
            
            if (PaymentAlgorithms.Count == 0)
            {
                var cardValidityAlgorithm = new LuhnCardValidator();
                
                PaymentAlgorithms.AddRange(new List<IPaymentAlgorithm>
                {
                    new CashPaymentAlgorithm(cashTerminal),
                    new CreditCardPaymentAlgorithm(creditCardTerminal, cardValidityAlgorithm)
                });
            }
        }
        
        public List<PaymentMethod> GetPaymentMethods()
        {
            return PaymentMethods;
        }
        
        public List<IPaymentAlgorithm> GetPaymentAlgorithms()
        {
            return PaymentAlgorithms;
        }
    }
}