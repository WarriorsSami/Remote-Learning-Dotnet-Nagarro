namespace VendingMachine.Domain.Business.IHelpersPayment;

public class CashPaymentMethod : IPaymentMethod
{
    public PaymentMethodType Id => PaymentMethodType.Cash;
    public string Name => "Cash";
}