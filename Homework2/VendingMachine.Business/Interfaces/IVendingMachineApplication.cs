namespace VendingMachine.Business.Interfaces
{
    public interface IVendingMachineApplication
    {
        bool UserIsLoggedIn { get; set; }
        void Run();
        void TurnOff();
    }
}