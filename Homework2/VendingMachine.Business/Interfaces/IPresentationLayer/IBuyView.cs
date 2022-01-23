using System.Collections.Generic;
using VendingMachine.Business.Helpers.Payment;
using VendingMachine.Business.Models;

namespace VendingMachine.Business.Interfaces.IPresentationLayer
{
    public interface IBuyView
    {
        void DisplayProduct(Product product);
        string AskForProductCode();
        int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
        void DisplayCommand(string command);
    }
}