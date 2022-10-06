using System;
using log4net;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business.IFactories;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Presentation.ICommands;

namespace VendingMachine.Presentation.Commands;

internal class PayCommand : IPayCommand
{
    private readonly ILog _logger;
    private readonly IAuthenticationService _authService;
    private readonly IUseCaseFactory _useCaseFactory;

    public PayCommand(
        IAuthenticationService authService,
        IUseCaseFactory useCaseFactory,
        ILog logger
    )
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        _useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public string Name => "pay";
    public string Description => "Execute payment";
    public bool CanExecute => !_authService.IsUserAuthenticated;

    public void Execute(Product product)
    {
        _useCaseFactory.Create<PayUseCase>().Execute(product);

        const string message = "Payment executed";
        _logger.Info(message);
    }
}
