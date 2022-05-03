namespace VendingMachine.Domain.Business.IHelpersPayment
{
    public interface IPaymentMethod
    {
        PaymentMethodType Id { get; }
        public string Name { get; }
    }
}
