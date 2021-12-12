using System;

namespace VendingMachine.Helpers.Payment
{
    internal class CashPaymentTerminal
    {
        public decimal AskForMoney()
        {
            return 0.0m;
        }
        
        public void GiveBackChange(decimal change)
        {
            throw new NotImplementedException();
        }
    }
}