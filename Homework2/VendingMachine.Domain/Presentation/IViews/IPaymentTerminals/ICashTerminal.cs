namespace VendingMachine.Domain.Presentation.IViews.IPaymentTerminals;

public interface ICashTerminal
{
    decimal AskForMoney();
    void GiveBackChange(decimal change);
}