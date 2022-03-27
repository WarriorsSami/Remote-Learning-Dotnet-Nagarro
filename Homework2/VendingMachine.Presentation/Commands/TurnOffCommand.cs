using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Presentation;

namespace VendingMachine.Presentation.Commands
{
    internal class TurnOffCommand : ICommand
    {
        private readonly IVendingMachineApplication _application;
        private readonly IUseCaseFactory _useCaseFactory;

        public TurnOffCommand(
            IVendingMachineApplication application,
            IUseCaseFactory useCaseFactory
        )
        {
            _application = application;
            _useCaseFactory = useCaseFactory;
        }

        public string Name => "exit";

        public string Description => "Go to live your life.";

        public bool CanExecute => _application.UserIsLoggedIn;

        public void Execute(params object[] args)
        {
            _useCaseFactory.Create<TurnOffUseCase>().Execute(_application);
        }
    }
}
