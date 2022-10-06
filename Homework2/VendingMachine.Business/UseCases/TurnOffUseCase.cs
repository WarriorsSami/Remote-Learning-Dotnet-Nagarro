using System;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Business.IUseCases;

namespace VendingMachine.Business.UseCases;

internal class TurnOffUseCase : IUseCase
{
    private readonly ITurnOffService _turnOffService;

    public TurnOffUseCase(ITurnOffService turnOffService)
    {
        _turnOffService = turnOffService ?? throw new ArgumentNullException(nameof(turnOffService));
    }

    public void Execute(params object[] args)
    {
        _turnOffService.TurnOff();
    }
}
