using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using VendingMachine;
using VendingMachine.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.Models;
using VendingMachine.PresentationLayer;
using VendingMachine.Repositories;
using VendingMachine.Services;
using VendingMachine.UseCases;

namespace VendingMachineTests
{
    public class BuyUseCaseTests
    {
        [Test]
        public void BuyExistingProduct()
        {
            const string requestedId = "1";
            var productExpected = new Product
            {
                ColumnId = 1,
                Name = "Coca Cola",
                Price = 1.5m,
                Quantity = 9
            };

            var productRepository = new ProductRepository();
            var buyProductService = new BuyProductService(productRepository);
            
            var buyView = new Mock<BuyView>();
            buyView.Setup(x =>
                x.AskForProductCode())
                .Returns(requestedId);
            
            var mainDisplay = new Mock<MainDisplay>();
            var useCases = new Mock<List<IUseCase>>();
            var application = new Mock<VendingMachineApplication>(useCases.Object, mainDisplay.Object);
            
            var buyUseCase = new BuyUseCase(application.Object, buyView.Object, buyProductService);

            buyUseCase.Execute();
            var result = productRepository.GetByCode(int.Parse(requestedId));
 
            Assert.AreEqual(productExpected.Quantity, result?.Quantity);
        }
        
        [Test]
        public void BuyNonExistingProduct()
        {
            const string requestedId = "10";
            var productRepository = new ProductRepository();
            var buyProductService = new BuyProductService(productRepository);
            
            var buyView = new Mock<BuyView>();
            buyView.Setup(x =>
                x.AskForProductCode())
                .Returns(requestedId);
            
            var mainDisplay = new Mock<MainDisplay>();
            var useCases = new Mock<List<IUseCase>>();
            var application = new Mock<VendingMachineApplication>(useCases.Object, mainDisplay.Object);
            
            var buyUseCase = new BuyUseCase(application.Object, buyView.Object, buyProductService);

            try
            {
                buyUseCase.Execute();
            }
            catch (ProductNotFoundException)
            {
                Assert.Pass();
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.Fail();
        }

        [Test]
        public void BuyOutOfStockProduct()
        {
            const string requestedId = "8";
            var productRepository = new ProductRepository();
            var buyProductService = new BuyProductService(productRepository);
            
            var buyView = new Mock<BuyView>();
            buyView.Setup(x =>
                x.AskForProductCode())
                .Returns(requestedId);
            
            var mainDisplay = new Mock<MainDisplay>();
            var useCases = new Mock<List<IUseCase>>();
            var application = new Mock<VendingMachineApplication>(useCases.Object, mainDisplay.Object);
            
            var buyUseCase = new BuyUseCase(application.Object, buyView.Object, buyProductService);
            
            try
            {
                buyUseCase.Execute();
            }
            catch (ProductOutOfStockException)
            {
                Assert.Pass();
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.Fail();
        }
        
        [Test]
        public void CancelOrder()
        {
            const string requestedId = "";
            var productRepository = new ProductRepository();
            var buyProductService = new BuyProductService(productRepository);
            
            var buyView = new Mock<BuyView>();
            buyView.Setup(x =>
                x.AskForProductCode())
                .Returns(requestedId);
            
            var mainDisplay = new Mock<MainDisplay>();
            var useCases = new Mock<List<IUseCase>>();
            var application = new Mock<VendingMachineApplication>(useCases.Object, mainDisplay.Object);
            
            var buyUseCase = new BuyUseCase(application.Object, buyView.Object, buyProductService);
            
            try
            {
                buyUseCase.Execute();
            }
            catch (CancelOrderException)
            {
                Assert.Pass();
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.Fail();
        }
    }
}