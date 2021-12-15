using System;
using VendingMachine.Interfaces.IHelpersPayment;

namespace VendingMachine.Helpers.Payment
{
    internal class CashPaymentTerminal: ICashTerminal
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