using System;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Presentation.Views
{
    internal abstract class DisplayBase: IDisplayBase
    {
        public void DisplayLine(string message, ConsoleColor color)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;
        }

        public void Display(string message, ConsoleColor color)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = oldColor;
        }
        
        public void DisplayError(Exception ex)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex);
            Console.ForegroundColor = oldColor;
        }
        
        public void Pause()
        {
            Console.ReadKey(true);
        }
    }
}