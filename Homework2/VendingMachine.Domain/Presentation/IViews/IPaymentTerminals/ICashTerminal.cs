namespace VendingMachine.Domain.Presentation.IViews.IPaymentTerminals;

public interface ICashTerminal
{
    decimal AskForMoney(decimal moneyToPay);
    void GiveBackChange(decimal change);
}
