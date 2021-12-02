using System;
using VendingMachine.CustomExceptions.LoginUseCaseExceptions;
using VendingMachine.PresentationLayer;

namespace VendingMachine.UseCases
{
    internal class LoginUseCase : IUseCase
    {
        private readonly VendingMachineApplication _application;
        private readonly MainDisplay _mainDisplay;

        public string Name => "login";

        public string Description => "Get access to administration buttons.";

        public bool CanExecute => !_application.UserIsLoggedIn;

        public LoginUseCase(VendingMachineApplication application, MainDisplay mainDisplay)
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