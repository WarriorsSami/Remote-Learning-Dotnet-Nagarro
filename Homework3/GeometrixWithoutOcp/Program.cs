using System;
using GeometrixWithoutOcp.ShapeModel;

namespace GeometrixWithoutOcp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var geometricShapes = new GeometricShapes
                {
                    new Rectangle { Height = 4, Width = 7 },
                    new Circle { Radius = 5 },
                    new Triangle { SideA = 3, SideB = 4, SideC = 5}
                };

                var area = geometricShapes.CalculateArea();
                Console.WriteLine($"Area: {area}");

                Pause();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }

        private static void DisplayError(Exception exception)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(exception.ToString());
            Console.ForegroundColor = oldColor;
        }
    }
}