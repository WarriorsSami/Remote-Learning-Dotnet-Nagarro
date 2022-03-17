namespace VendingMachine.Domain.Business.IHelpersPayment
{
    public class CreditCardPaymentMethod: IPaymentMethod
    {
        public PaymentMethodType Id => PaymentMethodType.CreditCard;
        public string Name => "Credit Card";
    }
}