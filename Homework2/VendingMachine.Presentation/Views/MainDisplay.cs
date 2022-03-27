using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Domain.Presentation;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Presentation.Views
{
    internal class MainDisplay : IMainDisplay 
    {
        public ICommand ChooseCommand(IEnumerable<ICommand> commands)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Available commands:");
            Console.WriteLine();
            
            var enumerable = commands.ToList();
            foreach (var useCase in enumerable)
                DisplayUseCase(useCase);

            while (true)
            {
                var rawValue = ReadCommandName();
                var selectedUseCase = enumerable.FirstOrDefault(x => x.Name == rawValue);

                if (selectedUseCase != null) return selectedUseCase;
                DisplayBase.DisplayLine("Invalid command. Please try again.", ConsoleColor.Red);
            }
        }

        private static void DisplayUseCase(ICommand commands)
        {
            var oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(commands.Name);

            Console.ForegroundColor = oldColor;

            Console.WriteLine(" - " + commands.Description);
        }

        private string ReadCommandName()
        {
            Console.WriteLine();
            DisplayBase.Display("Choose command: ", ConsoleColor.Cyan);
            var rawValue = Console.ReadLine();
            Console.WriteLine();

            return rawValue;
        }

        public string AskForPassword()
        {
            Console.WriteLine();
            DisplayBase.Display("Type the admin password: ", ConsoleColor.Cyan);
            return Console.ReadLine();
        }
    }
}