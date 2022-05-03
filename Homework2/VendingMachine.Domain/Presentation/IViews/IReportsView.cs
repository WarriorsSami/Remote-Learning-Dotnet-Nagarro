namespace VendingMachine.Domain.Presentation.IViews;
public interface IReportsView
{
    void AskForTimeInterval();
    void DisplaySuccessMessage(string detail, string filePath);
}
