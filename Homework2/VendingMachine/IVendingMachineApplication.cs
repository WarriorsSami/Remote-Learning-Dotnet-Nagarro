namespace VendingMachine
{
    internal interface IVendingMachineApplication
    {
        bool UserIsLoggedIn { get; set; }
        void Run();
        void TurnOff();
    }
}