﻿using System;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Business.UseCases;

internal class LoginUseCase : IUseCase
{
    private readonly IAuthenticationService _authService;
    private readonly IMainDisplay _mainDisplay;

    public LoginUseCase(IMainDisplay mainDisplay, IAuthenticationService authService)
    {
        _mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
    }

    public void Execute(params object[] args)
    {
        var password = _mainDisplay.AskForPassword();
        _authService.Login(password);
    }
}
