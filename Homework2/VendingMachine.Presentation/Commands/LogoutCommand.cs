using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Presentation;

namespace VendingMachine.Presentation.Commands
{
    internal class LogoutCommand : ICommand
    {
        private readonly IVendingMachineApplication _application;
        private readonly IUseCaseFactory _useCaseFactory;

        public LogoutCommand(IVendingMachineApplication application, IUseCaseFactory useCaseFactory)
        {
            _application = application;
            _useCaseFactory = useCaseFactory;
        }

        public string Name => "logout";

        public string Description => "Restrict access to administration buttons.";

        public bool CanExecute => _application.UserIsLoggedIn;

        public void Execute(params object[] args)
        {
            _useCaseFactory.Create<LogoutUseCase>().Execute(_application);
        }
    }
}
