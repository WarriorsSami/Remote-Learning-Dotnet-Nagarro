using System;

namespace VendingMachine.Helpers.Payment
{
    internal class CashPaymentTerminal
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