using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Interfaces.IUseCases;
using VendingMachine.UseCases;

namespace VendingMachine.PresentationLayer
{
    internal class MainDisplay : DisplayBase 
    {
        public IUseCase ChooseCommand(IEnumerable<IUseCase> useCases)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Available commands:");
            Console.WriteLine();
            
            var enumerable = useCases.ToList();
            foreach (var useCase in enumerable)
                DisplayUseCase(useCase);

            while (true)
            {
                var rawValue = ReadCommandName();
                var selectedUseCase = enumerable.FirstOrDefault(x => x.Name == rawValue);

                if (selectedUseCase != null) return selectedUseCase;
                DisplayLine("Invalid command. Please try again.", ConsoleColor.Red);
            }
        }

        private static void DisplayUseCase(IUseCase useCase)
        {
            var oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(useCase.Name);

            Console.ForegroundColor = oldColor;

            Console.WriteLine(" - " + useCase.Description);
        }

        private string ReadCommandName()
        {
            Console.WriteLine();
            Display("Choose command: ", ConsoleColor.Cyan);
            var rawValue = Console.ReadLine();
            Console.WriteLine();

            return rawValue;
        }

        public string AskForPassword()
        {
            Console.WriteLine();
            Display("Type the admin password: ", ConsoleColor.Cyan);
            return Console.ReadLine();
        }
    }
}