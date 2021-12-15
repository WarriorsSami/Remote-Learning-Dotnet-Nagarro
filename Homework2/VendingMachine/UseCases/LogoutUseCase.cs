using System;
using VendingMachine.Interfaces.IUseCases;

namespace VendingMachine.UseCases
{
    internal class LogoutUseCase : IUseCase
    {
        private readonly VendingMachineApplication _application;

        public string Name => "logout";

        public string Description => "Restrict access to administration buttons.";

        public bool CanExecute => _application.UserIsLoggedIn;

        public LogoutUseCase(VendingMachineApplication application)
        {
            _application = application ?? throw new ArgumentNullException(nameof(application));
        }

        public void Execute()
        {
            _application.UserIsLoggedIn = false;
        }
    }
}