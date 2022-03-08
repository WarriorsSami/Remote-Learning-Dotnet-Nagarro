using System.Collections.Generic;
using VendingMachine.Business.Helpers.Payment;

namespace VendingMachine.Domain.Business.IHelpersPayment
{
    public interface IPaymentFactory
    {
        List<PaymentMethod> GetPaymentMethods();
        List<IPaymentAlgorithm> GetPaymentAlgorithms();
    }
}