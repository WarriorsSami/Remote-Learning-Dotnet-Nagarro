using System.Collections.Generic;
using VendingMachine.Business.Helpers.Payment;
using VendingMachine.Business.Interfaces.IHelpersPayment;

namespace VendingMachine.Business.Interfaces.IRepositories
{
    public interface IPaymentRepository
    {
        List<PaymentMethod> GetPaymentMethods();
        List<IPaymentAlgorithm> GetPaymentAlgorithms();
    }
}