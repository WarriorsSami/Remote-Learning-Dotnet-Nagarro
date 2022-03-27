using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Presentation;

namespace VendingMachine.Presentation.Commands
{
    internal class PayCommand : ICommand
    {
        private readonly IVendingMachineApplication _application;
        private readonly IUseCaseFactory _useCaseFactory;

        public PayCommand(
            IVendingMachineApplication application,
            IUseCaseFactory useCaseFactory
        )
        {
            _application = application;
            _useCaseFactory = useCaseFactory;
        }

        public string Name => "pay";
        public string Description => "Execute payment";
        public bool CanExecute => !_application.UserIsLoggedIn;

        public void Execute(params object[] args)
        {
            _useCaseFactory.Create<PayUseCase>().Execute(args);
        }
    }
}
