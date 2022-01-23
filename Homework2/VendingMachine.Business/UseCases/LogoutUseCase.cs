using System;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Interfaces.IUseCases;

namespace VendingMachine.Business.UseCases
{
    internal class LogoutUseCase : IUseCase
    {
        private readonly IVendingMachineApplication _application;

        public string Name => "logout";

        public string Description => "Restrict access to administration buttons.";

        public bool CanExecute => _application.UserIsLoggedIn;

        public LogoutUseCase(IVendingMachineApplication application)
        {
            _application = application ?? throw new ArgumentNullException(nameof(application));
        }

        public void Execute()
        {
            _application.UserIsLoggedIn = false;
        }
    }
}