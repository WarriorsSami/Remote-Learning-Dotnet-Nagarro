using System;

namespace VendingMachine.Business.CustomExceptions.LoginUseCaseExceptions;

public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException() { }

    public InvalidCredentialsException(string message) : base(message) { }

    public InvalidCredentialsException(string message, Exception innerException)
        : base(message, innerException) { }
}
