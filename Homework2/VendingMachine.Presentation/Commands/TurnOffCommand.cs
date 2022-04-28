using System;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Presentation.ICommands;

namespace VendingMachine.Presentation.Commands;

internal class TurnOffCommand : ICommand
{
    private readonly IAuthenticationService _authService;
    private readonly ITurnOffService _turnOffService;
    private readonly IUseCaseFactory _useCaseFactory;

    public TurnOffCommand(
        IAuthenticationService authService,
        IUseCaseFactory useCaseFactory,
        ITurnOffService turnOffService
    )
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        _useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        _turnOffService = turnOffService ?? throw new ArgumentNullException(nameof(turnOffService));
    }

    public string Name => "exit";

    public string Description => "Go to live your life.";

    public bool CanExecute => _authService.IsUserAuthenticated;

    public void Execute(params object[] args)
    {
        _useCaseFactory.Create<TurnOffUseCase>().Execute(_turnOffService);
    }
}