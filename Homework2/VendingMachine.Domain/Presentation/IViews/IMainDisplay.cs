using System.Collections.Generic;

namespace VendingMachine.Domain.Presentation.IViews
{
    public interface IMainDisplay
    {
        ICommand ChooseCommand(IEnumerable<ICommand> commands);
        string AskForPassword();
    }
}
