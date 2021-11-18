using System;
using GrandCircus.CircusModel;
using GrandCircus.Presentation;

namespace GrandCircus
{
    internal static class Program
    {
        private const string AnimalFileIn = "animals.in";
        private const string DefaultCircusName = "Ringling Bros. and Barnum & Bailey Circus";
        
        private static void Main()
        {
            var arena = new Arena();

            var circus = new Circus(arena, DefaultCircusName, AnimalFileIn);
            circus.Perform();

            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
}