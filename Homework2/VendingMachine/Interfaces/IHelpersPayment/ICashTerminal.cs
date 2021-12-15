namespace VendingMachine.Helpers.Payment
{
    internal interface ICashTerminal
    {
        decimal AskForMoney();
        void GiveBackChange(decimal change);
    }
}