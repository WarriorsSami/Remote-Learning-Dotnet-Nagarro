namespace CaesarCipher.DataDecryptor.Business.ClientLogic
{
    public interface IQuoteRepository
    {
        string GetOne();
        void PutOne(string text);
    }
}