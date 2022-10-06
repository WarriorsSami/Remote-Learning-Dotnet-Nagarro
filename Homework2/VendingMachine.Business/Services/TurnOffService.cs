using log4net;
using VendingMachine.Domain.Business.IServices;

namespace VendingMachine.Business.Services;

public class TurnOffService : ITurnOffService
{
    public bool TurnOffRequested { get; set; }

    public void Initialize()
    {
        TurnOffRequested = false;
    }

    public void TurnOff()
    {
        TurnOffRequested = true;
    }
}
