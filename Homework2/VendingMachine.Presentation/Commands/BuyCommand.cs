using System;
using log4net;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business.IFactories;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Presentation.ICommands;

namespace VendingMachine.Presentation.Commands;

internal class BuyCommand : ICommand
{
    private readonly ILog _logger;
    private readonly IAuthenticationService _authService;
    private readonly IUseCaseFactory _useCaseFactory;

    public BuyCommand(
        IAuthenticationService authService,
        IUseCaseFactory useCaseFactory,
        ILog logger
    )
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        _useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public string Name => "buy";
    public string Description => "Buy & Pay for a product";
    public bool CanExecute => !_authService.IsUserAuthenticated;

    public void Execute()
    {
        _useCaseFactory.Create<BuyUseCase>().Execute();

        const string message = "The user has successfully bought a product";
        _logger.Info(message);
    }
}
