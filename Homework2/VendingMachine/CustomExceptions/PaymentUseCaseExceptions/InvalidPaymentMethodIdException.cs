using System;

namespace VendingMachine.CustomExceptions.PaymentUseCaseExceptions
{
    internal class InvalidPaymentMethodIdException: Exception
    {
        public InvalidPaymentMethodIdException()
        {
        }
        
        public InvalidPaymentMethodIdException(string message) : base(message)
        {
        }
        
        public InvalidPaymentMethodIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}