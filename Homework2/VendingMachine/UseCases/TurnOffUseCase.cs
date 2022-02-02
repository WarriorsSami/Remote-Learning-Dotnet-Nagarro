﻿using VendingMachine.Interfaces.IUseCases;

namespace VendingMachine.UseCases
{
    internal class TurnOffUseCase : IUseCase
    {
        private readonly VendingMachineApplication _application;

        public string Name => "exit";

        public string Description => "Go to live your life.";

        public bool CanExecute => _application.UserIsLoggedIn;

        public TurnOffUseCase(VendingMachineApplication application)
        {
            _application = application;
        }

        public void Execute()
        {
            _application.TurnOff();
        }
    }
}