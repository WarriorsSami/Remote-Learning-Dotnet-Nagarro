using System;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Presentation.ICommands;

namespace VendingMachine.Presentation.Commands
{
    internal class PayCommand : IPayCommand
    {
        private readonly IAuthenticationService _authService;
        private readonly IUseCaseFactory _useCaseFactory;

        public PayCommand(IAuthenticationService authService, IUseCaseFactory useCaseFactory)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public string Name => "pay";
        public string Description => "Execute payment";
        public bool CanExecute => !_authService.IsUserAuthenticated;

        public void Execute(decimal price)
        {
            _useCaseFactory.Create<PayUseCase>().Execute(price);
        }
    }
}
