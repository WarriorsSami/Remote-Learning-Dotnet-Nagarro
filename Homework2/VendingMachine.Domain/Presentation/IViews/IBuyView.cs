using System.Collections.Generic;
using VendingMachine.Business.Helpers.Payment;
using VendingMachine.DataAccess.Models;

namespace VendingMachine.Domain.Presentation.IViews
{
    public interface IBuyView
    {
        void DisplayProduct(Product product);
        string AskForProductCode();
        int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
        void DisplayCommand(string command);
    }
}