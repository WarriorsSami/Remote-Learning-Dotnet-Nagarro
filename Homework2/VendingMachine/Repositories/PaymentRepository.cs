using System.Collections.Generic;
using VendingMachine.Helpers.Payment;

namespace VendingMachine.Repositories
{
    internal class PaymentRepository: IPaymentRepository
    {
        private static readonly List<PaymentMethod> PaymentMethods = new();
        private static readonly List<IPaymentAlgorithm> PaymentAlgorithms = new();

        public PaymentRepository()
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
                var cashTerminal = new CashPaymentTerminal();
                var creditCardTerminal = new CreditCardPaymentTerminal();
                
                PaymentAlgorithms.AddRange(new List<IPaymentAlgorithm>
                {
                    new CashPaymentAlgorithm(cashTerminal),
                    new CreditCardPaymentAlgorithm(creditCardTerminal)
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