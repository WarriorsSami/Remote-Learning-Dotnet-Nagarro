using System;
using System.Collections.Generic;
using iQuest.TheUniverse.Application.GetAllStars;
using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Presentation.Commands
{
    internal class DisplayAllStarsCommand
    {
        private readonly RequestBus _requestBus;
        public DisplayAllStarsCommand(RequestBus requestBus)
        {
            _requestBus = requestBus ?? throw new ArgumentNullException(nameof(requestBus));
        }

        public void Execute()
        {
            var request = new GetAllStarsRequest();
            var response = _requestBus.Send<IEnumerable<StarInfo>>(request);

            DisplayStars(response);
        }

        private static void DisplayStars(IEnumerable<StarInfo> starInfos)
        {
            Console.WriteLine();

            Console.WriteLine("The stars in this universe:");

            foreach (var starInfo in starInfos)
                Console.WriteLine($"Star '{starInfo.StarName}' from galaxy '{starInfo.GalaxyName}'.");
        }
    }
}