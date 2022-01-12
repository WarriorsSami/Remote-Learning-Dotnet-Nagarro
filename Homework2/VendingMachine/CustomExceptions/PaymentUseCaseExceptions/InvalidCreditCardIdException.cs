using System;

namespace VendingMachine.CustomExceptions.PaymentUseCaseExceptions
{
    internal class InvalidCreditCardIdException: Exception
    {
        public InvalidCreditCardIdException()
        {
        }
        
        public InvalidCreditCardIdException(string message) : base(message)
        {
        }
        
        public InvalidCreditCardIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}