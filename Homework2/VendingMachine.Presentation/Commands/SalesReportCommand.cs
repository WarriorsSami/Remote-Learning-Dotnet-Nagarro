using System;
using log4net;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business.IFactories;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Presentation.ICommands;

namespace VendingMachine.Presentation.Commands;

internal class SalesReportCommand : ICommand
{
    private readonly ILog _logger;
    private readonly IAuthenticationService _authService;
    private readonly IUseCaseFactory _useCaseFactory;

    public SalesReportCommand(
        IAuthenticationService authService,
        IUseCaseFactory useCaseFactory,
        ILog logger
    )
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        _useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public string Name => "sales";

    public string Description =>
        "Retrieve an XML/Json sales report file for a specific date range.";

    public bool CanExecute => _authService.IsUserAuthenticated;

    public void Execute()
    {
        _useCaseFactory.Create<SalesReportUseCase>().Execute();

        const string message = "Sales report generated successfully.";
        _logger.Info(message);
    }
}
