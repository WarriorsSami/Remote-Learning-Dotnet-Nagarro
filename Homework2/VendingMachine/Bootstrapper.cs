using System;
using System.Collections.Generic;
using VendingMachine.Business;
using VendingMachine.Business.Interfaces.IUseCases;
using VendingMachine.Business.UseCases;
using VendingMachine.DataAccess.Repositories;
using VendingMachine.Presentation.PresentationLayer;

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
            var buyView = new BuyView();
            var productContextFactory = new ProductContextFactory();
            var productRepository = new ProductPersistentRepository(
                productContextFactory.CreateDbContext(Array.Empty<string>()));
            var paymentRepository = new PaymentRepository();
            var useCases = new List<IUseCase>();
            
            var vendingMachineApplication = new VendingMachineApplication(useCases, mainDisplay);
            var paymentUseCase = new PaymentUseCase(vendingMachineApplication, buyView, paymentRepository);

            useCases.AddRange(new IUseCase[]
            {
                new LoginUseCase(vendingMachineApplication, mainDisplay),
                new LogoutUseCase(vendingMachineApplication),
                new TurnOffUseCase(vendingMachineApplication),
                new LookUseCase(shelfView, productRepository),
                new BuyUseCase(vendingMachineApplication, buyView, productRepository, paymentUseCase)
            });

            return vendingMachineApplication;
        }
    }
}