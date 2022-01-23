using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Interfaces.IUseCases;

namespace VendingMachine.Business.UseCases
{
    internal class TurnOffUseCase : IUseCase
    {
        private readonly IVendingMachineApplication _application;

        public string Name => "exit";

        public string Description => "Go to live your life.";

        public bool CanExecute => _application.UserIsLoggedIn;

        public TurnOffUseCase(IVendingMachineApplication application)
        {
            _application = application;
        }

        public void Execute()
        {
            _application.TurnOff();
        }
    }
}