using System;
using VendingMachine.Domain.Presentation.IViews;
using VendingMachine.Domain.Presentation.IViews.IPaymentTerminals;

namespace VendingMachine.Presentation.Views.PaymentTerminals;

public class CashPaymentTerminal : ICashTerminal
{
    public decimal AskForMoney(decimal moneyToPay)
    {
        DisplayBase.DisplayLine($"You still have to pay {moneyToPay}$!", ConsoleColor.Red);
        var currentMoney = decimal.Parse(Console.ReadLine() ?? "0.0");
        return currentMoney;
    }

    public void GiveBackChange(decimal change)
    {
        Console.WriteLine($"Your change is {change}$!");
    }
}
