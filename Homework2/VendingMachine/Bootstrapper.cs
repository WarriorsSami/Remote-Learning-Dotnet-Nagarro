using System.Collections.Generic;
using VendingMachine.PresentationLayer;
using VendingMachine.UseCases;

namespace VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            var vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication()
        {
            var mainDisplay = new MainDisplay();
            var shelfView = new ShelfView();
            var useCases = new List<IUseCase>();

            var vendingMachineApplication = new VendingMachineApplication(useCases, mainDisplay);

            useCases.AddRange(new IUseCase[]
            {
                new LoginUseCase(vendingMachineApplication, mainDisplay),
                new LogoutUseCase(vendingMachineApplication),
                new TurnOffUseCase(vendingMachineApplication),
                new LookUseCase(shelfView)
            });

            return vendingMachineApplication;
        }
    }
}