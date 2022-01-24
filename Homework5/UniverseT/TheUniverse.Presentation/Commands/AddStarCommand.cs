using System;
using iQuest.TheUniverse.Application.AddStar;
using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Presentation.Commands
{
    internal class AddStarCommand
    {
        private readonly RequestBus _requestBus;
        
        public AddStarCommand(RequestBus requestBus)
        {
            this._requestBus = requestBus ?? throw new ArgumentNullException(nameof(requestBus));
        }

        public void Execute()
        {
            var addStarRequest = new AddStarRequest
            {
                StarDetailsProvider = new StarDetailsProvider()
            };
            var response = _requestBus.Send<bool>(addStarRequest);

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
            Console.WriteLine("The star was successfully created.");
            Console.ForegroundColor = oldColor;
        }

        private static void DisplayFailureMessage()
        {
            Console.WriteLine();

            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failed to create the star. The star already exists.");
            Console.ForegroundColor = oldColor;
        }
    }
}