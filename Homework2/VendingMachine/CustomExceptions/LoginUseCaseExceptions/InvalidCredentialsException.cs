using System;

namespace VendingMachine.CustomExceptions.LoginUseCaseExceptions
{
    internal class InvalidCredentialsException: Exception
    {
        public InvalidCredentialsException()
        {
        }

        public InvalidCredentialsException(string message) : base(message)
        {
        }

        public InvalidCredentialsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}