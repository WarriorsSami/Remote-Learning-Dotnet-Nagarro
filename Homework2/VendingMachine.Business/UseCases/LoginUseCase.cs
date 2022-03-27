using System;
using System.Runtime.CompilerServices;
using VendingMachine.Business.CustomExceptions.LoginUseCaseExceptions;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.Presentation.IViews;

[assembly: InternalsVisibleTo("VendingMachine.Presentation")]
namespace VendingMachine.Business.UseCases
{
    internal class LoginUseCase : IUseCase
    {
        private readonly IMainDisplay _mainDisplay;

        public LoginUseCase(IMainDisplay mainDisplay)
        {
            _mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
        }

        public void Execute(params object[] args)
        {
            var password = _mainDisplay.AskForPassword();
            var application = (IVendingMachineApplication)args[0];

            if (password == "super")
                application.UserIsLoggedIn = true;
            else
                throw new InvalidCredentialsException("Invalid password");
        }
    }
}