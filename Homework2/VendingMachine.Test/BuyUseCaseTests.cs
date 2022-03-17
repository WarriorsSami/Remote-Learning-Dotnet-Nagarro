using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using VendingMachine.Business.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Test
{
    internal class BuyUseCaseTests
    {
        private readonly IVendingMachineApplication _application;
        private readonly IPaymentUseCase _paymentUseCase;
        private readonly IProductRepository _productRepository;
        
        public BuyUseCaseTests()
        {
            var mockApplication = new Mock<IVendingMachineApplication>(); 
            mockApplication.Setup(x =>
                x.UserIsLoggedIn
                ).Returns(false);
            
            _application = mockApplication.Object;
            
            var mockPaymentUseCase = new Mock<IPaymentUseCase>();
            mockPaymentUseCase.Setup(x =>
                x.Execute(It.IsAny<decimal>())
                ).Verifiable(); 
            mockPaymentUseCase.Setup(x =>
                x.CanExecute
                ).Returns(true);
            
            _paymentUseCase = mockPaymentUseCase.Object;
            
            var listOfProduct = new List<Product>
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
                ).Returns(listOfProduct);
            
            mockProductRepository.Setup(x =>
                x.GetById(It.IsAny<int>())
                ).Returns((int id) => listOfProduct.Find(x => x.ColumnId == id));
            
            mockProductRepository.Setup(x =>
                x.UpdateQuantity(It.IsAny<int>(), It.IsAny<int>())
                ).Callback((int id, int quantity) =>
                {
                    var product = listOfProduct.Find(x => x.ColumnId == id);
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
            
            var mockBuyView = new Mock<IBuyView>();
            mockBuyView.Setup(x =>
                x.AskForProductCode()
                ).Returns(requestedId);
            
            var buyUseCase = new BuyUseCase(_application, 
                mockBuyView.Object,
                _productRepository,
                _paymentUseCase);

            buyUseCase.Execute();
            var result = _productRepository.GetById(int.Parse(requestedId));
 
            Assert.AreEqual(productExpected.Quantity, result?.Quantity);
        }
        
        [Test]
        public void BuyNonExistingProduct()
        {
            const string requestedId = "10";
            
            var mockBuyView = new Mock<IBuyView>();
            mockBuyView.Setup(x =>
                x.AskForProductCode())
                .Returns(requestedId);
            
            var buyUseCase = new BuyUseCase(_application,
                mockBuyView.Object,
                _productRepository,
                _paymentUseCase);

            Assert.Throws<ProductNotFoundException>(() => buyUseCase.Execute());
        }

        [Test]
        public void BuyOutOfStockProduct()
        {
            const string requestedId = "8";
            
            var mockBuyView = new Mock<IBuyView>();
            mockBuyView.Setup(x =>
                x.AskForProductCode())
                .Returns(requestedId);
            
            var buyUseCase = new BuyUseCase(_application,
                mockBuyView.Object,
                _productRepository,
                _paymentUseCase);
            
            Assert.Throws<ProductOutOfStockException>(() => buyUseCase.Execute()); 
        }
        
        [Test]
        public void CancelOrder()
        {
            const string requestedId = "";
            
            var mockBuyView = new Mock<IBuyView>();
            mockBuyView.Setup(x =>
                x.AskForProductCode())
                .Returns(requestedId);
            
            var buyUseCase = new BuyUseCase(_application,
                mockBuyView.Object,
                _productRepository,
                _paymentUseCase);
            
            Assert.Throws<CancelOrderException>(() => buyUseCase.Execute());  
        }
    }
}