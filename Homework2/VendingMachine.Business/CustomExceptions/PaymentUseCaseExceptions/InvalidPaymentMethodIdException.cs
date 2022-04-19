using System;

namespace VendingMachine.Business.CustomExceptions.PaymentUseCaseExceptions
{
    public class InvalidPaymentMethodIdException : Exception
    {
        public InvalidPaymentMethodIdException() { }

        public InvalidPaymentMethodIdException(string message) : base(message) { }

        public InvalidPaymentMethodIdException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
