using System;
using log4net;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business.IFactories;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Presentation.ICommands;

namespace VendingMachine.Presentation.Commands;

internal class SupplyExistingProductCommand : ICommand
{
    private readonly ILog _logger;
    private readonly IAuthenticationService _authService;
    private readonly IUseCaseFactory _useCaseFactory;

    public SupplyExistingProductCommand(
        IAuthenticationService authService,
        IUseCaseFactory useCaseFactory,
        ILog logger
    )
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        _useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public string Name => "supply_old";

    public string Description => "Supply existing product";

    public bool CanExecute => _authService.IsUserAuthenticated;

    public void Execute()
    {
        _useCaseFactory.Create<SupplyExistingProductUseCase>().Execute();

        const string message = "Product was successfully supplied";
        _logger.Info(message);
    }
}
