using System;
using VendingMachine.Business.Interfaces.IHelpersPayment;

namespace VendingMachine.Business.Helpers.Payment
{
    public class CashPaymentTerminal: ICashTerminal
    {
        public decimal AskForMoney()
        {
            var currentMoney = decimal.Parse(Console.ReadLine() ?? "0.0");   
            return currentMoney;
        }
        
        public void GiveBackChange(decimal change)
        {
            Console.WriteLine($"Your change is {change}$!");
        }
    }
}