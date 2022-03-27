using System.Collections.Generic;
using VendingMachine.Domain.Presentation;

namespace VendingMachine.Domain.Business
{
    public interface IVendingMachineApplication
    {
        bool UserIsLoggedIn { get; set; }
        void AddRangeCommand(IEnumerable<ICommand> commands);
        void Run();
        void TurnOff();
    }
}