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
            catch (InvalidCredentialsException e)
            {
                DisplayError(e);
                Pause();
            }
            catch (ProductNotFoundException e)
            {
                DisplayError(e);
                Pause();
            }
            catch (ProductOutOfStockException e)
            {
                DisplayError(e);
                Pause();
            }
            catch (CancelOrderException e)
            {
                DisplayError(e);
                Pause();
            }
            catch (Exception e)
            {
                DisplayError(e);
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
