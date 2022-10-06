using System;
using log4net;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business.IFactories;
using VendingMachine.Domain.Presentation.ICommands;

namespace VendingMachine.Presentation.Commands;

internal class LookCommand : ICommand
{
    private readonly ILog _logger;
    private readonly IUseCaseFactory _useCaseFactory;

    public LookCommand(IUseCaseFactory useCaseFactory, ILog logger)
    {
        _useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public string Name => "list";
    public string Description =>
        "Display the list of available products stored in the vending machine";
    public bool CanExecute => true;

    public void Execute()
    {
        _useCaseFactory.Create<LookUseCase>().Execute();

        const string message = "The list of available products is displayed";
        _logger.Info(message);
    }
}
