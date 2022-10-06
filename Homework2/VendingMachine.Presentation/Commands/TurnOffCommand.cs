using System;
using log4net;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business.IFactories;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Presentation.ICommands;

namespace VendingMachine.Presentation.Commands;

internal class TurnOffCommand : ICommand
{
    private readonly ILog _logger;
    private readonly IAuthenticationService _authService;
    private readonly IUseCaseFactory _useCaseFactory;

    public TurnOffCommand(
        IAuthenticationService authService,
        IUseCaseFactory useCaseFactory,
        ILog logger
    )
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        _useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public string Name => "exit";

    public string Description => "Go to live your life.";

    public bool CanExecute => _authService.IsUserAuthenticated;

    public void Execute()
    {
        _useCaseFactory.Create<TurnOffUseCase>().Execute();

        const string message = "The user has left the vending machine";
        _logger.Info(message);
    }
}
