using System.Collections.Generic;
using VendingMachine.Domain.Presentation.ICommands;

namespace VendingMachine.Domain.Presentation.IViews
{
    public interface IMainDisplay
    {
        ICommand ChooseCommand(IEnumerable<ICommand> commands);
        string AskForPassword();
    }
}
