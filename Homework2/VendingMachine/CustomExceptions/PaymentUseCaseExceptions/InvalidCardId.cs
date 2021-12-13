using System;

namespace VendingMachine.CustomExceptions.PaymentUseCaseExceptions
{
    internal class InvalidCardId: Exception
    {
        public InvalidCardId()
        {
        }
        
        public InvalidCardId(string message) : base(message)
        {
        }
        
        public InvalidCardId(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}