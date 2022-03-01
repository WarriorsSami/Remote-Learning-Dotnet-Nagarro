namespace VendingMachine.Domain.Business.IHelpersPayment
{
    public interface ICardValidityAlgorithm
    {
        bool IsValid(string cardNumber);
    }
}