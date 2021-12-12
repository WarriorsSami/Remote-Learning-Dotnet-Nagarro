using System;

namespace VendingMachine.CustomExceptions.PaymentUseCaseExceptions
{
    internal class InvalidPaymentMethodId: Exception
    {
        public InvalidPaymentMethodId()
        {
        }
        
        public InvalidPaymentMethodId(string message) : base(message)
        {
        }
        
        public InvalidPaymentMethodId(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}