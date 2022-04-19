using System;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Presentation.ICommands;

namespace VendingMachine.Presentation.Commands
{
    internal class LoginCommand : ICommand
    {
        private readonly IAuthenticationService _authService;
        private readonly IUseCaseFactory _useCaseFactory;

        public LoginCommand(IAuthenticationService authService, IUseCaseFactory useCaseFactory)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public string Name => "login";

        public string Description => "Get access to administration buttons.";

        public bool CanExecute => !_authService.IsUserAuthenticated;

        public void Execute(params object[] args)
        {
            _useCaseFactory.Create<LoginUseCase>().Execute(_authService);
        }
    }
}
