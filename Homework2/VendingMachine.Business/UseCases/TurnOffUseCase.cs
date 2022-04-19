using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Business.IUseCases;

namespace VendingMachine.Business.UseCases
{
    internal class TurnOffUseCase : IUseCase
    {
        public void Execute(params object[] args)
        {
            var turnOffService = (ITurnOffService)args[0];
            turnOffService.TurnOff();
        }
    }
}
