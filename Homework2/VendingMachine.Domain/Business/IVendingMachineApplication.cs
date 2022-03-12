using System.Collections.Generic;
using VendingMachine.Domain.Business.IUseCases;

namespace VendingMachine.Domain.Business
{
    public interface IVendingMachineApplication
    {
        bool UserIsLoggedIn { get; set; }
        void AddUseCase(IUseCase useCase);
        void AddRangeUseCase(IEnumerable<IUseCase> useCases);
        void Run();
        void TurnOff();
    }
}