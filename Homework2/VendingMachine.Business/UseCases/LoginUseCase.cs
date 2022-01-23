using System;
using VendingMachine.Business.CustomExceptions.LoginUseCaseExceptions;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Interfaces.IPresentationLayer;
using VendingMachine.Business.Interfaces.IUseCases;

namespace VendingMachine.Business.UseCases
{
    internal class LoginUseCase : IUseCase
    {
        private readonly IVendingMachineApplication _application;
        private readonly IMainDisplay _mainDisplay;

        public string Name => "login";

        public string Description => "Get access to administration buttons.";

        public bool CanExecute => !_application.UserIsLoggedIn;

        public LoginUseCase(IVendingMachineApplication application, IMainDisplay mainDisplay)
        {
            _application = application ?? throw new ArgumentNullException(nameof(application));
            _mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
        }

        public void Execute()
        {
            var password = _mainDisplay.AskForPassword();

            if (password == "supercalifragilisticexpialidocious")
                _application.UserIsLoggedIn = true;
            else
                throw new InvalidCredentialsException("Invalid password");
        }
    }
}