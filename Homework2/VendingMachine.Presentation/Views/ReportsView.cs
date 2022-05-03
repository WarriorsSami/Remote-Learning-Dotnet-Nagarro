using System;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Presentation.Views;

internal class ReportsView : IReportsView
{
    public void AskForTimeInterval()
    {
        throw new NotImplementedException();
    }

    public void DisplaySuccessMessage(string detail)
    {
        DisplayBase.DisplayLine(
            $"{detail} report has been successfully generated",
            ConsoleColor.Cyan
        );
    }
}
