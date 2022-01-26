using System;
using iQuest.TheUniverse.Infrastructure;
using iQuest.TheUniverse.Presentation.Commands;

namespace iQuest.TheUniverse.Presentation
{
    public class Prompter
    {
        private readonly RequestBus _requestBus;
        private bool _exitWasRequested;

        public Prompter(RequestBus requestBus)
        {
            _requestBus = requestBus ?? throw new ArgumentNullException(nameof(requestBus));
        }

        public void ProcessUserInput()
        {
            _exitWasRequested = false;

            while (!_exitWasRequested)
            {
                try
                {
                    var command = ReadCommandFromConsole();
                    ProcessCommand(command);
                }
                catch (Exception ex)
                {
                    DisplayError(ex);
                }
            }
        }

        private static string ReadCommandFromConsole()
        {
            Console.WriteLine();
            Console.Write("Universe> ");
            return Console.ReadLine();
        }

        private void ProcessCommand(string command)
        {
            switch (command)
            {
                case "add-galaxy":
                    var command1 = new AddGalaxyCommand(_requestBus);
                    command1.Execute();
                    break;

                case "add-star":
                    var command2 = new AddStarCommand(_requestBus);
                    command2.Execute();
                    break;

                case "display-stars":
                    var command3 = new DisplayAllStarsCommand(_requestBus);
                    command3.Execute();
                    break;

                case "exit":
                case "kill":
                case "collapse":
                    _exitWasRequested = true;
                    break;

                default:
                    throw new Exception("Invalid command.");
            }
        }

        private static void DisplayError(Exception exception)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(exception);
            Console.ForegroundColor = oldColor;
        }
    }
}