namespace VendingMachine.Domain.Presentation
{
    public interface ICommand
    {
        string Name { get; }
        string Description { get; } 
        bool CanExecute { get; } 
        
        void Execute(params object[] args);
    }
}