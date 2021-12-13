using System.Collections.Generic;
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
        private readonly IProductRepository _productRepository;
        
        public BuyUseCaseTests()
        {
            var listProduct = new List<Product>
            {
                new()
                {
                    ColumnId = 0,
                    Name = "Coca Cola",
                    Price = 1.5m,
                    Quantity = 9
                },
                new()
                {
                    ColumnId = 2,
                    Name = "Fanta",
                    Price = 1.5m,
                    Quantity = 10
                },
                new()
                {
                    ColumnId = 3,
                    Name = "Sprite",
                    Price = 1.5m,
                    Quantity = 10
                },
                new()
                {
                    ColumnId = 4,
                    Name = "Pepsi",
                    Price = 1.5m,
                    Quantity = 10
                },
                new()
                {
                    ColumnId = 5,
                    Name = "7up",
                    Price = 1.5m,
                    Quantity = 10
                },
                new()
                {
                    ColumnId = 6,
                    Name = "Fanta Light",
                    Price = 1.5m,
                    Quantity = 10
                },
                new()
                {
                    ColumnId = 7,
                    Name = "Coca Cola Zero",
                    Price = 1.5m,
                    Quantity = 1
                },
                new()
                {
                    ColumnId = 8,
                    Name = "Coca Cola Light",
                    Price = 1.5m,
                    Quantity = 0
                }
            };
            
            var mockProductRepository = new Mock<IProductRepository>();
            
            mockProductRepository.Setup(x =>
                x.GetAll()
                ).Returns(listProduct);
            
            mockProductRepository.Setup(x =>
                x.GetById(It.IsAny<int>())
                ).Returns((int id) => listProduct.Find(x => x.ColumnId == id));
            
            mockProductRepository.Setup(x =>
                x.UpdateQuantity(It.IsAny<int>(), It.IsAny<int>())
                ).Callback((int id, int quantity) =>
                {
                    var product = listProduct.Find(x => x.ColumnId == id);
                    if (product != null)
                    {
                        product.Quantity = quantity;
                    }
                });
           
            _productRepository = mockProductRepository.Object;
        }
        
        [Test]
        public void BuyExistingProduct()
        {
            const string requestedId = "0";
            var productExpected = new Product
            {
                ColumnId = 0,
                Name = "Coca Cola",
                Price = 1.5m,
                Quantity = 8
            };

            var paymentUseCase = new Mock<IPaymentUseCase>();
            paymentUseCase.Setup(x =>
                x.Execute(productExpected.Price)
            ).Verifiable();
            paymentUseCase.Setup(x =>
                x.CanExecute
            ).Returns(true);
            
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
                _productRepository,
                paymentUseCase.Object);

            buyUseCase.Execute();
            var result = _productRepository.GetById(int.Parse(requestedId));
 
            Assert.AreEqual(productExpected.Quantity, result?.Quantity);
        }
        
        [Test]
        public void BuyNonExistingProduct()
        {
            const string requestedId = "10";
            
            var paymentUseCase = new Mock<IPaymentUseCase>();
            paymentUseCase.Setup(x =>
                x.Execute(It.IsAny<decimal>())
            ).Verifiable();
            paymentUseCase.Setup(x =>
                x.CanExecute
            ).Returns(true);
            
            var buyView = new Mock<IBuyView>();
            buyView.Setup(x =>
                x.AskForProductCode())
                .Returns(requestedId);
            
            var application = new Mock<IVendingMachineApplication>();
            
            var buyUseCase = new BuyUseCase(application.Object,
                buyView.Object,
                _productRepository,
                paymentUseCase.Object);

            Assert.Throws<ProductNotFoundException>(() => buyUseCase.Execute());
        }

        [Test]
        public void BuyOutOfStockProduct()
        {
            const string requestedId = "8";
            
            var paymentUseCase = new Mock<IPaymentUseCase>();
            paymentUseCase.Setup(x =>
                x.Execute(It.IsAny<decimal>())
            ).Verifiable();
            paymentUseCase.Setup(x =>
                x.CanExecute
            ).Returns(true);

            var buyView = new Mock<IBuyView>();
            buyView.Setup(x =>
                x.AskForProductCode())
                .Returns(requestedId);
            
            var application = new Mock<IVendingMachineApplication>();
            
            var buyUseCase = new BuyUseCase(application.Object,
                buyView.Object,
                _productRepository,
                paymentUseCase.Object);
            
            Assert.Throws<ProductOutOfStockException>(() => buyUseCase.Execute()); 
        }
        
        [Test]
        public void CancelOrder()
        {
            const string requestedId = "";
            
            var paymentUseCase = new Mock<IPaymentUseCase>();
            paymentUseCase.Setup(x =>
                x.Execute(It.IsAny<decimal>())
            ).Verifiable();
            paymentUseCase.Setup(x =>
                x.CanExecute
            ).Returns(true);
            
            var buyView = new Mock<IBuyView>();
            buyView.Setup(x =>
                x.AskForProductCode())
                .Returns(requestedId);
            
            var application = new Mock<IVendingMachineApplication>();
            
            var buyUseCase = new BuyUseCase(application.Object,
                buyView.Object,
                _productRepository,
                paymentUseCase.Object);
            
            Assert.Throws<CancelOrderException>(() => buyUseCase.Execute());  
        }
    }
}