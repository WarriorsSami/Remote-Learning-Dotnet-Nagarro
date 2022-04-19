using DustInTheWind.ConsoleTools;

namespace iQuest.BigTree.Presentation
{
    public class ApplicationHeaderControl
    {
        public void Display()
        {
            CustomConsole.WriteLineEmphasies("Big Tree");
            CustomConsole.WriteLineEmphasies(new string('=', 79));
        }
    }
}