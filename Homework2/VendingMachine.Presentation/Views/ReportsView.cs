using System;
using VendingMachine.Domain.Dtos;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Presentation.Views;

internal class ReportsView : IReportsView
{
    public TimeInterval AskForTimeInterval()
    {
        DisplayBase.DisplayLine(
            "In order to generate a this sort of report, you have to choose a range of days to inspect.",
            ConsoleColor.Cyan
        );

        var endDate = DateTime.UtcNow;
        DisplayBase.DisplayLine($"The current date is {endDate:yyyy MMMM dd}!", ConsoleColor.Cyan);

        DisplayBase.DisplayLine(
            "Now, please enter the number of days you want to inspect:",
            ConsoleColor.Yellow
        );
        var days = int.Parse(Console.ReadLine() ?? string.Empty);
        var startDate = endDate.AddDays(-days);

        return new TimeInterval { Start = startDate, End = endDate };
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
