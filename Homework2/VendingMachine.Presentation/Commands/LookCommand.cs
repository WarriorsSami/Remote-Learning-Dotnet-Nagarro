using System;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business.IFactories;
using VendingMachine.Domain.Presentation.ICommands;

namespace VendingMachine.Presentation.Commands;

internal class LookCommand : ICommand
{
    private readonly IUseCaseFactory _useCaseFactory;

    public LookCommand(IUseCaseFactory useCaseFactory)
    {
        _useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
    }

    public string Name => "list";
    public string Description =>
        "Display the list of available products stored in the vending machine";
    public bool CanExecute => true;

    public void Execute()
    {
        _useCaseFactory.Create<LookUseCase>().Execute();
    }
}
