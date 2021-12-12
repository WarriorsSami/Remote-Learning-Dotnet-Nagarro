namespace VendingMachine.Helpers.Payment
{
    internal interface IPaymentAlgorithm
    {
        public PaymentMethodType Id { get; }
        public string Name { get; }
        void Run(decimal price);
    }
}