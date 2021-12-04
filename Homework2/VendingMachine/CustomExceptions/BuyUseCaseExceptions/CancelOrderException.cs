using System;

namespace VendingMachine.CustomExceptions.BuyUseCaseExceptions
{
    public class CancelOrderException: Exception
    {
        public CancelOrderException()
        {
        }
        
        public CancelOrderException(string message) : base(message)
        {
        }
        
        public CancelOrderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}