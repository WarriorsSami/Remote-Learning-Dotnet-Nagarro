using VendingMachine.Domain.Dtos;

namespace VendingMachine.Domain.Presentation.IViews;

public interface IReportsView
{
    TimeInterval AskForTimeInterval();
    void DisplaySuccessMessage(string detail, string filePath);
}
