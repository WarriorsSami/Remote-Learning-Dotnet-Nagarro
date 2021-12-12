using System.Collections.Generic;
using VendingMachine.Helpers.Payment;

namespace VendingMachine.Repositories
{
    internal interface IPaymentRepository
    {
        List<PaymentMethod> GetPaymentMethods();
        List<IPaymentAlgorithm> GetPaymentAlgorithms();
    }
}