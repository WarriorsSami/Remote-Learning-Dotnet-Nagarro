namespace VendingMachine.Domain.Business
{
    public interface IVendingMachineApplication
    {
        bool UserIsLoggedIn { get; set; }
        void Run();
        void TurnOff();
    }
}