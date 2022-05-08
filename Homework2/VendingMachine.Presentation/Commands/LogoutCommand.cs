﻿using System;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business.IFactories;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Presentation.ICommands;

namespace VendingMachine.Presentation.Commands;

internal class LogoutCommand : ICommand
{
    private readonly IAuthenticationService _authService;
    private readonly IUseCaseFactory _useCaseFactory;

    public LogoutCommand(IAuthenticationService authService, IUseCaseFactory useCaseFactory)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        _useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
    }

    public string Name => "logout";

    public string Description => "Restrict access to administration buttons.";

    public bool CanExecute => _authService.IsUserAuthenticated;

    public void Execute()
    {
        _useCaseFactory.Create<LogoutUseCase>().Execute();
    }
}
