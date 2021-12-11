using Moq;
using NUnit.Framework;
using VendingMachine;
using VendingMachine.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.Models;
using VendingMachine.PresentationLayer;
using VendingMachine.Repositories;
using VendingMachine.UseCases;

namespace VendingMachineTests
{
    internal class BuyUseCaseTests
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

            var buyView = new Mock<IBuyView>();
            buyView.Setup(x =>
                x.AskForProductCode()
                ).Returns(requestedId);
            
            var application = new Mock<IVendingMachineApplication>();
            application.Setup(x =>
                x.UserIsLoggedIn
                ).Returns(false);
            
            var buyUseCase = new BuyUseCase(application.Object, 
                buyView.Object,
                productRepository);

            buyUseCase.Execute();
            var result = productRepository.GetByCode(int.Parse(requestedId));
 
            Assert.AreEqual(productExpected.Quantity, result?.Quantity);
        }
        
        [Test]
        public void BuyNonExistingProduct()
        {
            const string requestedId = "10";
            var productRepository = new ProductRepository(); 
            
            var buyView = new Mock<IBuyView>();
            buyView.Setup(x =>
                x.AskForProductCode())
                .Returns(requestedId);
            
            var application = new Mock<IVendingMachineApplication>();
            
            var buyUseCase = new BuyUseCase(application.Object,
                buyView.Object,
                productRepository);

            Assert.Throws<ProductNotFoundException>(() => buyUseCase.Execute());
        }

        [Test]
        public void BuyOutOfStockProduct()
        {
            const string requestedId = "8";
            var productRepository = new ProductRepository();

            var buyView = new Mock<IBuyView>();
            buyView.Setup(x =>
                x.AskForProductCode())
                .Returns(requestedId);
            
            
            var application = new Mock<IVendingMachineApplication>();
            
            var buyUseCase = new BuyUseCase(application.Object,
                buyView.Object,
                productRepository);
            
            Assert.Throws<ProductOutOfStockException>(() => buyUseCase.Execute()); 
        }
        
        [Test]
        public void CancelOrder()
        {
            const string requestedId = "";
            var productRepository = new ProductRepository();
            
            var buyView = new Mock<IBuyView>();
            buyView.Setup(x =>
                x.AskForProductCode())
                .Returns(requestedId);
            
            var application = new Mock<IVendingMachineApplication>();
            
            var buyUseCase = new BuyUseCase(application.Object,
                buyView.Object,
                productRepository);

            Assert.Throws<CancelOrderException>(() => buyUseCase.Execute());  
        }
    }
}