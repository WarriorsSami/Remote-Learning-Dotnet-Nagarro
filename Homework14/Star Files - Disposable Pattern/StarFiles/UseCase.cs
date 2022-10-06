using System;
using iQuest.StarFiles.UniverseModel;

namespace iQuest.StarFiles
{
    internal class UseCase
    {
        public void Execute()
        {
            string starFilePath, binaryStarFilePath1, binaryStarFilePath2;

            using (var universe = new Universe())
            {
                starFilePath = GenerateStar(universe);
                (binaryStarFilePath1, binaryStarFilePath2) = GenerateBinaryStar(universe);
            }

            DisplayFileContent(starFilePath);
            DisplayFileContent(binaryStarFilePath1);
            DisplayFileContent(binaryStarFilePath2);
        }

        private static string GenerateStar(Universe universe)
        {
            Console.WriteLine();
            Console.WriteLine("Generating star.");

            const string starName = "Betelgeuse";
            var createdFilePath = universe.CreateStarFromTemplate(starName);

            Console.WriteLine($"Finished generating star: '{starName}'.");
            Console.WriteLine($"File: {createdFilePath}");
            return createdFilePath;
        }

        private static Tuple<string, string> GenerateBinaryStar(Universe universe)
        {
            Console.WriteLine();
            Console.WriteLine("Generating binary star.");

            const string starName = "Sirius";
            var createdFilePath = universe.CreateBinaryStar(starName);

            Console.WriteLine($"Finished generating binary star '{starName}'.");
            Console.WriteLine($"Files: {createdFilePath}");
            return createdFilePath;
        }

        private static void DisplayFileContent(string filePath)
        {
            Console.WriteLine();
            Console.WriteLine($"File: '{filePath}'");
            Console.WriteLine("Content:");

            using var winApiFile = new WinApiFile(filePath);
            var text = winApiFile.ReadAll();
            Console.WriteLine(text);
        }
    }
}