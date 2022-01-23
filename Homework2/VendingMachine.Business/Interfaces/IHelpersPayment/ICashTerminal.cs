namespace VendingMachine.Business.Interfaces.IHelpersPayment
{
    public interface ICashTerminal
    {
        decimal AskForMoney();
        void GiveBackChange(decimal change);
    }
}