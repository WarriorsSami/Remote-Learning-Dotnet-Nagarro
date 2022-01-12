using VendingMachine.Helpers.Payment;

namespace VendingMachine.Interfaces.IHelpersPayment
{
    internal interface IPaymentAlgorithm
    {
        public PaymentMethodType Id { get; }
        public string Command { get; }
        public string Name { get; }
        void Run(decimal price);
    }
}