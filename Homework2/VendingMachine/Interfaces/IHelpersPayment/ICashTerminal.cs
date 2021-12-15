namespace VendingMachine.Interfaces.IHelpersPayment
{
    internal interface ICashTerminal
    {
        decimal AskForMoney();
        void GiveBackChange(decimal change);
    }
}