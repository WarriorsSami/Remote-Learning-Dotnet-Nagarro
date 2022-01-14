namespace VendingMachine.Interfaces.IHelpersPayment
{
    internal interface ICardValidityAlgorithm
    {
        bool IsValid(string cardNumber);
    }
}