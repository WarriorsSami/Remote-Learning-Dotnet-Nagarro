namespace VendingMachine.Business.Interfaces.IHelpersPayment
{
    public interface ICardValidityAlgorithm
    {
        bool IsValid(string cardNumber);
    }
}