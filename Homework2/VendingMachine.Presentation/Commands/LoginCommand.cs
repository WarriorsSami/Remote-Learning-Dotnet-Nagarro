using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Presentation;

namespace VendingMachine.Presentation.Commands
{
    internal class LoginCommand : ICommand
    {
        private readonly IVendingMachineApplication _application;
        private readonly IUseCaseFactory _useCaseFactory;

        public LoginCommand(IVendingMachineApplication application, IUseCaseFactory useCaseFactory)
        {
            _application = application;
            _useCaseFactory = useCaseFactory;
        }

        public string Name => "login";

        public string Description => "Get access to administration buttons.";

        public bool CanExecute => !_application.UserIsLoggedIn;

        public void Execute(params object[] args)
        {
            _useCaseFactory.Create<LoginUseCase>().Execute(_application);
        }
    }
}
