using System;
using VendingMachine.Business.Interfaces.IPresentationLayer;

namespace VendingMachine.Presentation.PresentationLayer
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