using System;
using GrandCircus.CircusModel;
using GrandCircus.Presentation;

namespace GrandCircus
{
    internal static class Program
    {
        private const string AnimalInFile =
            "C:\\Users\\asus\\RiderProjects\\Remote-Learning-Dotnet-Nagarro\\Homework1\\GrandCircus\\animals.in";
        
        private static void Main()
        {
            var arena = new Arena();
            var animalFactory = new AnimalFactory(AnimalInFile);

            var circus = new Circus(arena, "Ringling Bros. and Barnum & Bailey Circus", animalFactory);
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