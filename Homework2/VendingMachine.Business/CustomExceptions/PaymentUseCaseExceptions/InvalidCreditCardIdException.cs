using System;

namespace VendingMachine.Business.CustomExceptions.PaymentUseCaseExceptions;

public class InvalidCreditCardIdException : Exception
{
    public InvalidCreditCardIdException() { }

    public InvalidCreditCardIdException(string message) : base(message) { }

    public InvalidCreditCardIdException(string message, Exception innerException)
        : base(message, innerException) { }
}
