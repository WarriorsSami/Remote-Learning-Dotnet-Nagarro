using System;

namespace VendingMachine
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var bootstrapper = new Bootstrapper();
                bootstrapper.Run();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
                Pause();
            }
        }

        private static void DisplayError(Exception ex)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex);
            Console.ForegroundColor = oldColor;
        }

        private static void Pause()
        {
            Console.ReadKey(true);
        }
    }
}
