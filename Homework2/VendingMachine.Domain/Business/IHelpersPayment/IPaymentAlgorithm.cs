namespace VendingMachine.Domain.Business.IHelpersPayment;

public interface IPaymentAlgorithm
{
    public PaymentMethodType Id { get; }
    public string Command { get; }
    public string Name { get; }
    void Run(decimal price);
}