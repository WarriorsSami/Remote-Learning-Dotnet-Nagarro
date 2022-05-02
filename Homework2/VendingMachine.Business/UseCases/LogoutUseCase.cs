using System;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Business.IUseCases;

namespace VendingMachine.Business.UseCases;

internal class LogoutUseCase : IUseCase
{
    private readonly IAuthenticationService _authService;

    public LogoutUseCase(IAuthenticationService authService)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
    }

    public void Execute(params object[] args)
    {
        _authService.Logout();
    }
}