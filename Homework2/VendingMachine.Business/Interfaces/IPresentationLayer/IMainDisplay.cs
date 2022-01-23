using System.Collections.Generic;
using VendingMachine.Business.Interfaces.IUseCases;

namespace VendingMachine.Business.Interfaces.IPresentationLayer
{
    public interface IMainDisplay: IDisplayBase
    {
        IUseCase ChooseCommand(IEnumerable<IUseCase> useCases);
        string AskForPassword();
    }
}