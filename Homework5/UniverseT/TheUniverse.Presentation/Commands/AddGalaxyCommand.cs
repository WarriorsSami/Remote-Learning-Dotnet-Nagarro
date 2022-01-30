using System;
using iQuest.TheUniverse.Application.AddGalaxy;
using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Presentation.Commands
{
    internal class AddGalaxyCommand
    {
        private readonly RequestBus _requestBus;

        public AddGalaxyCommand(RequestBus requestBus)
        {
            this._requestBus = requestBus ?? throw new ArgumentNullException(nameof(requestBus));
        }

        public void Execute()
        {
            var addGalaxyRequest = new AddGalaxyRequest
            {
                GalaxyDetailsProvider = new GalaxyDetailsProvider()
            };
            var response = _requestBus.Send<bool>(addGalaxyRequest);

            if (response)
                DisplaySuccessMessage();
            else
                DisplayFailureMessage();
        }

        private static void DisplaySuccessMessage()
        {
            Console.WriteLine();

            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The galaxy was successfully created.");
            Console.ForegroundColor = oldColor;
        }

        private static void DisplayFailureMessage()
        {
            Console.WriteLine();

            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failed to create the galaxy. The galaxy already exists.");
            Console.ForegroundColor = oldColor;
        }
    }
}