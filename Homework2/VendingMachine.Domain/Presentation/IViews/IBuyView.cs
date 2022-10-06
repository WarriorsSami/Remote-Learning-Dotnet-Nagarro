using System.Collections.Generic;
using VendingMachine.Domain.Business.IHelpersPayment;

namespace VendingMachine.Domain.Presentation.IViews;

public interface IBuyView : IDisplayView
{
    string AskForProductCode();
    int AskForPaymentMethod(IEnumerable<IPaymentMethod> paymentMethods);
    void DisplayCommand(string command);
}
