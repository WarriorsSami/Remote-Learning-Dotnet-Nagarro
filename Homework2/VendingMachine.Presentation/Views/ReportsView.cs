using System;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Presentation.Views;

internal class ReportsView : IReportsView
{
    public void AskForTimeInterval()
    {
        throw new NotImplementedException();
    }

    public void DisplaySuccessMessage(string detail, string filePath)
    {
        DisplayBase.DisplayLine(
            $"A new {detail} Report has been successfully generated.\n"
                + $"Please refer to the file {filePath} for a more detailed output.",
            ConsoleColor.Green
        );
    }
}
