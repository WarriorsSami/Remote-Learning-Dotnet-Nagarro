using System;

namespace VendingMachine.CustomExceptions.BuyUseCaseExceptions
{
    internal class ProductOutOfStockException: Exception
    {
        public ProductOutOfStockException()
        {
        }
        
        public ProductOutOfStockException(string message) : base(message)
        {
        }
        
        public ProductOutOfStockException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}