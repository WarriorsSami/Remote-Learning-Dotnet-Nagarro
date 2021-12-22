using System;
using System.Reflection;

namespace VendingMachine.CustomExceptions.BuyUseCaseExceptions
{
    internal class CancelOrderException: Exception
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