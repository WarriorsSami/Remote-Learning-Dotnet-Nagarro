using System.Collections.Generic;
using VendingMachine.Helpers.Payment;
using VendingMachine.Interfaces.IHelpersPayment;

namespace VendingMachine.Interfaces.IRepositories
{
    internal interface IPaymentRepository
    {
        List<PaymentMethod> GetPaymentMethods();
        List<IPaymentAlgorithm> GetPaymentAlgorithms();
    }
}