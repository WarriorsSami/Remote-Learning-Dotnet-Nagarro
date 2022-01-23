namespace VendingMachine.Business.Interfaces.IUseCases
{
    public interface IUseCase
    {
        string Name { get; }

        string Description { get; }

        bool CanExecute { get; }

        void Execute();
    }
}