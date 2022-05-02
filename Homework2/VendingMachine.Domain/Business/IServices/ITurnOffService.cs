namespace VendingMachine.Domain.Business.IServices
{
    public interface ITurnOffService
    {
        bool TurnOffRequested { get; set; }
        void Initialize();
        void TurnOff();
    }
}