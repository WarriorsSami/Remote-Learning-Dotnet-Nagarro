using System;
using DustInTheWind.ConsoleTools;

namespace iQuest.StarFiles
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                var useCase = new UseCase();
                useCase.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                CustomConsole.WriteError(ex);
            }
            finally
            {
                Pause.QuickDisplay();
            }
        }
    }
}