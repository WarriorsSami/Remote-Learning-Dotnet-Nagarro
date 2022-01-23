using VendingMachine.Business.Helpers.Payment;

namespace VendingMachine.Business.Interfaces.IHelpersPayment
{
    public interface IPaymentAlgorithm
    {
        public PaymentMethodType Id { get; }
        public string Command { get; }
        public string Name { get; }
        void Run(decimal price);
    }
}