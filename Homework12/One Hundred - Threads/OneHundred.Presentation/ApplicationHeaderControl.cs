using DustInTheWind.ConsoleTools;

namespace iQuest.OneHundred.Presentation
{
    public class ApplicationHeaderControl
    {
        public void Display()
        {
            CustomConsole.WriteLineEmphasies("Thread Concurrency");
            CustomConsole.WriteLineEmphasies(new string('=', 79));
        }
    }
}
