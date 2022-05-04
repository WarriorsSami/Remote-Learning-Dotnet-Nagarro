using System;
using DustInTheWind.ConsoleTools;
using DustInTheWind.ConsoleTools.Controls;

namespace iQuest.StarFiles
{
    internal class Program
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