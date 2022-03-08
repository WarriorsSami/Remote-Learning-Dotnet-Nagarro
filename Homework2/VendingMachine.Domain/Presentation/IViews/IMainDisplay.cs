using System.Collections.Generic;
using VendingMachine.Domain.Business.IUseCases;

namespace VendingMachine.Domain.Presentation.IViews
{
    public interface IMainDisplay: IDisplayBase
    {
        IUseCase ChooseCommand(IEnumerable<IUseCase> useCases);
        string AskForPassword();
    }
}