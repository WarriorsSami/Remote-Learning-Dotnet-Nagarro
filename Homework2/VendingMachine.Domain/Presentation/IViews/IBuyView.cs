using System.Collections.Generic;
using VendingMachine.Domain.Business.IHelpersPayment;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Domain.Presentation.IViews
{
    public interface IBuyView
    {
        void DisplayProduct(Product product);
        string AskForProductCode();
        int AskForPaymentMethod(IEnumerable<IPaymentMethod> paymentMethods);
        void DisplayCommand(string command);
    }
}
