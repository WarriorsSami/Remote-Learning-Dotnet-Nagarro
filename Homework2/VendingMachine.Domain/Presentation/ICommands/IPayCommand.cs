namespace VendingMachine.Domain.Presentation.ICommands;

public interface IPayCommand
{
    string Name { get; }
    string Description { get; } 
    bool CanExecute { get; }
    void Execute(decimal price);
}