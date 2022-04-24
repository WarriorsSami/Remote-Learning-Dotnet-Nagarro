namespace VendingMachine.Domain.Presentation.ICommands
{
    public interface ICommand
    {
        string Name { get; }
        string Description { get; }
        bool CanExecute { get; }

        void Execute(params object[] args);
    }
}
