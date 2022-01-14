using System;
using System.Collections.Generic;
using iQuest.TheUniverse.Application;
using iQuest.TheUniverse.Application.AddGalaxy;
using iQuest.TheUniverse.Application.AddStar;
using iQuest.TheUniverse.Application.GetAllStars;
using iQuest.TheUniverse.Infrastructure;
using iQuest.TheUniverse.Presentation;

namespace iQuest.TheUniverse
{
    internal class Bootstrapper
    {
        private static RequestBus requestBus;

        public void Run()
        {
            requestBus = new RequestBus();
            ConfigureRequestBus();
            DisplayApplicationHeader();
            RunUserCommandProcessLoop();
        }

        private static void ConfigureRequestBus()
        {
            requestBus.RegisterHandler<StarInfo, AddGalaxyRequest, AddGalaxyRequestHandler>();
            requestBus.RegisterHandler<StarInfo, AddStarRequest, AddStarRequestHandler>();
            requestBus.RegisterHandler<StarInfo, GetAllStarsRequest, GetAllStarsRequestHandler>();
        }

        private static void DisplayApplicationHeader()
        {
            ApplicationHeader applicationHeader = new ApplicationHeader();
            applicationHeader.Display();
        }

        private static void RunUserCommandProcessLoop()
        {
            Prompter prompter = new Prompter(requestBus);
            prompter.ProcessUserInput();
        }
    }
}