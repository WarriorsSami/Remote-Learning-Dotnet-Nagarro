namespace VendingMachine.UseCases
{
    internal interface IPaymentUseCase
    {
        string Name { get; }
        string Description { get; }
        bool CanExecute { get; }
        void Execute(decimal price);
    }
}