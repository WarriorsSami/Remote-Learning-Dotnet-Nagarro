﻿using VendingMachine.Interfaces.IHelpersPayment;

namespace VendingMachine.Helpers.Payment
{
    internal class CashPaymentAlgorithm: IPaymentAlgorithm
    {
        public PaymentMethodType Id => PaymentMethodType.Cash;
        public string Name => "Cash";
        public string Command => "Please insert cash to match the price!";
        
        private readonly ICashTerminal _terminal;

        public CashPaymentAlgorithm(ICashTerminal terminal)
        {
            _terminal = terminal;
        }

        public void Run(decimal price)
        {
             var currentAmountOfMoney = 0.0m;
             while (currentAmountOfMoney < price)
             {
                 currentAmountOfMoney += _terminal.AskForMoney();
                 if (currentAmountOfMoney > price)
                 {
                     _terminal.GiveBackChange(currentAmountOfMoney - price);
                 }
             }
        }
    }
}