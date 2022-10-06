using System;
using log4net;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business.IFactories;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Presentation.ICommands;

namespace VendingMachine.Presentation.Commands;

internal class LoginCommand : ICommand
{
    private readonly ILog _logger;
    private readonly IAuthenticationService _authService;
    private readonly IUseCaseFactory _useCaseFactory;

    public LoginCommand(
        IAuthenticationService authService,
        IUseCaseFactory useCaseFactory,
        ILog logger
    )
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        _useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public string Name => "login";

    public string Description => "Get access to administration buttons.";

    public bool CanExecute => !_authService.IsUserAuthenticated;

    public void Execute()
    {
        _useCaseFactory.Create<LoginUseCase>().Execute();

        const string message = "The user is now logged in";
        _logger.Info(message);
    }
}
