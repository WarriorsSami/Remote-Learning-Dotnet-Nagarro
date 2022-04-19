using System;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Presentation.ICommands;

namespace VendingMachine.Presentation.Commands
{
    internal class BuyCommand : ICommand
    {
        private readonly IAuthenticationService _authService;
        private readonly IUseCaseFactory _useCaseFactory;

        public BuyCommand(IAuthenticationService authService, IUseCaseFactory useCaseFactory)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public string Name => "buy";
        public string Description => "Buy & Pay for a product";
        public bool CanExecute => !_authService.IsUserAuthenticated;

        public void Execute(params object[] args)
        {
            _useCaseFactory.Create<BuyUseCase>().Execute();
        }
    }
}
