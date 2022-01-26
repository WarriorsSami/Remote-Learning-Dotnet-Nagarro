using System.Collections.Generic;
using iQuest.TheUniverse.Application.AddGalaxy;
using iQuest.TheUniverse.Application.AddStar;
using iQuest.TheUniverse.Application.GetAllStars;
using iQuest.TheUniverse.Infrastructure;
using iQuest.TheUniverse.Presentation;

namespace iQuest.TheUniverse
{
    internal class Bootstrapper
    {
        private static RequestBus _requestBus;

        public void Run()
        {
            _requestBus = new RequestBus();
            ConfigureRequestBus();
            DisplayApplicationHeader();
            RunUserCommandProcessLoop();
        }

        private static void ConfigureRequestBus()
        {
            _requestBus.RegisterHandler<bool, AddGalaxyRequest, AddGalaxyRequestHandler>();
            _requestBus.RegisterHandler<bool, AddStarRequest, AddStarRequestHandler>();
            _requestBus.RegisterHandler<IEnumerable<StarInfo>, GetAllStarsRequest, GetAllStarsRequestHandler>();
        }

        private static void DisplayApplicationHeader()
        {
            ApplicationHeader applicationHeader = new ApplicationHeader();
            applicationHeader.Display();
        }

        private static void RunUserCommandProcessLoop()
        {
            Prompter prompter = new Prompter(_requestBus);
            prompter.ProcessUserInput();
        }
    }
}