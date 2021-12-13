using System.Collections.Generic;
using VendingMachine.Helpers.Payment;
using VendingMachine.Models;

namespace VendingMachine.PresentationLayer
{
    internal interface IBuyView
    {
        void DisplayProduct(Product product);
        string AskForProductCode();
        int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
        void DisplayCommand(string command);
    }
}