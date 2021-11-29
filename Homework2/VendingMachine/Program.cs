using System;
using VendingMachine.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.CustomExceptions.LoginUseCaseExceptions;

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
            catch (Exception e)
            {
                DisplayError(e);
                Pause();
            }
        }

        public static void DisplayError(Exception ex)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex);
            Console.ForegroundColor = oldColor;
        }

        public static void Pause()
        {
            Console.ReadKey(true);
        }
    }
}
