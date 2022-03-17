using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using VendingMachine.Business.CustomExceptions.PaymentUseCaseExceptions;
using VendingMachine.Business.Helpers.Payment;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Business.IHelpersPayment;
using VendingMachine.Domain.Presentation.IViews;
using VendingMachine.Domain.Presentation.IViews.IPaymentTerminals;

namespace VendingMachine.Test
{
    internal class PaymentUseCaseTests
    {
        private readonly IVendingMachineApplication _application;

        private readonly ICardValidityAlgorithm _cardValidityAlgorithm;

        private readonly IEnumerable<IPaymentMethod> _listOfPaymentMethods;

        public PaymentUseCaseTests()
        {
            _cardValidityAlgorithm = new LuhnCardValidator();

            var mockApplication = new Mock<IVendingMachineApplication>();
            mockApplication.Setup(x => x.UserIsLoggedIn).Returns(false);

            _application = mockApplication.Object;

            _listOfPaymentMethods = new List<IPaymentMethod>
            {
                new CashPaymentMethod(),
                new CreditCardPaymentMethod()
            };
        }

        [Test]
        public void SuccessfulCashPaymentAttempt()
        {
            const int requestedPaymentMethodId = 0;
            const decimal requestedPrice = 10.0m;
            const decimal requestedChange = 8.0m;

            var mockCardValidator = new Mock<ICardValidityAlgorithm>();
            var mockCashTerminal = new Mock<ICashTerminal>();
            var mockCreditCardTerminal = new Mock<ICardTerminal>();

            mockCashTerminal
                .SetupSequence(x => x.AskForMoney())
                .Returns(1)
                .Returns(2)
                .Returns(5)
                .Returns(10);

            mockCashTerminal
                .Setup(x => x.GiveBackChange(It.IsAny<decimal>()))
                .Callback<decimal>(
                    x =>
                    {
                        if (x != requestedChange)
                            Assert.Fail();
                    }
                )
                .Verifiable();

            var listOfPaymentAlgorithm = new List<IPaymentAlgorithm>
            {
                new CashPaymentAlgorithm(mockCashTerminal.Object),
                new CreditCardPaymentAlgorithm(
                    mockCreditCardTerminal.Object,
                    mockCardValidator.Object
                )
            };

            var mockBuyView = new Mock<IBuyView>();

            mockBuyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<IPaymentMethod>>()))
                .Returns(requestedPaymentMethodId);

            var paymentUseCase = new PaymentUseCase(
                _application,
                mockBuyView.Object,
                listOfPaymentAlgorithm,
                _listOfPaymentMethods
            );

            Assert.DoesNotThrow(() => paymentUseCase.Execute(requestedPrice));
        }

        [Test]
        public void FailedPaymentAttempt_DueToInvalidPaymentMethodIdProvided()
        {
            const decimal requestedPrice = 10.0m;
            const int requestedPaymentMethodId = 2;

            var mockCardValidator = new Mock<ICardValidityAlgorithm>();
            var mockCashTerminal = new Mock<ICashTerminal>();
            var mockCreditCardTerminal = new Mock<ICardTerminal>();

            var listOfPaymentAlgorithm = new List<IPaymentAlgorithm>
            {
                new CashPaymentAlgorithm(mockCashTerminal.Object),
                new CreditCardPaymentAlgorithm(
                    mockCreditCardTerminal.Object,
                    mockCardValidator.Object
                )
            };

            var mockBuyView = new Mock<IBuyView>();

            mockBuyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<IPaymentMethod>>()))
                .Returns(requestedPaymentMethodId);

            var paymentUseCase = new PaymentUseCase(
                _application,
                mockBuyView.Object,
                listOfPaymentAlgorithm,
                _listOfPaymentMethods
            );

            Assert.Throws<InvalidPaymentMethodIdException>(
                () => paymentUseCase.Execute(requestedPrice)
            );
        }

        [Test]
        public void SuccessfulCreditCardPaymentAttempt()
        {
            const decimal requestedPrice = 10.0m;
            const string requestedCardNumber = "79927398713";
            const int requestedPaymentMethodId = 1;

            var mockCashTerminal = new Mock<ICashTerminal>();
            var mockCreditCardTerminal = new Mock<ICardTerminal>();

            mockCreditCardTerminal.Setup(x => x.AskForCardNumber()).Returns(requestedCardNumber);

            var listOfPaymentAlgorithm = new List<IPaymentAlgorithm>
            {
                new CashPaymentAlgorithm(mockCashTerminal.Object),
                new CreditCardPaymentAlgorithm(
                    mockCreditCardTerminal.Object,
                    _cardValidityAlgorithm
                )
            };

            var mockBuyView = new Mock<IBuyView>();

            mockBuyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<IPaymentMethod>>()))
                .Returns(requestedPaymentMethodId);

            var paymentUseCase = new PaymentUseCase(
                _application,
                mockBuyView.Object,
                listOfPaymentAlgorithm,
                _listOfPaymentMethods
            );

            Assert.DoesNotThrow(() => paymentUseCase.Execute(requestedPrice));
        }

        [Test]
        public void FailedCreditCardPaymentAttempt_DueToInvalidCreditCardIdProvided()
        {
            const decimal requestedPrice = 10.0m;
            const string requestedCardNumber = "7992739871";
            const int requestedPaymentMethodId = 1;

            var mockCashTerminal = new Mock<ICashTerminal>();
            var mockCreditCardTerminal = new Mock<ICardTerminal>();

            mockCreditCardTerminal.Setup(x => x.AskForCardNumber()).Returns(requestedCardNumber);

            var listOfPaymentAlgorithm = new List<IPaymentAlgorithm>
            {
                new CashPaymentAlgorithm(mockCashTerminal.Object),
                new CreditCardPaymentAlgorithm(
                    mockCreditCardTerminal.Object,
                    _cardValidityAlgorithm
                )
            };

            var mockBuyView = new Mock<IBuyView>();

            mockBuyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<IPaymentMethod>>()))
                .Returns(requestedPaymentMethodId);

            var paymentUseCase = new PaymentUseCase(
                _application,
                mockBuyView.Object,
                listOfPaymentAlgorithm,
                _listOfPaymentMethods
            );

            Assert.Throws<InvalidCreditCardIdException>(
                () => paymentUseCase.Execute(requestedPrice)
            );
        }

        [Test]
        public void FailedCreditCardPaymentAttempt_DueToInvalidCreditCardIdFormat()
        {
            const decimal requestedPrice = 10.0m;
            const string requestedCardNumber = "7992739871asd";
            const int requestedPaymentMethodId = 1;

            var mockCashTerminal = new Mock<ICashTerminal>();
            var mockCreditCardTerminal = new Mock<ICardTerminal>();

            mockCreditCardTerminal.Setup(x => x.AskForCardNumber()).Returns(requestedCardNumber);

            var listOfPaymentAlgorithm = new List<IPaymentAlgorithm>
            {
                new CashPaymentAlgorithm(mockCashTerminal.Object),
                new CreditCardPaymentAlgorithm(
                    mockCreditCardTerminal.Object,
                    _cardValidityAlgorithm
                )
            };

            var mockBuyView = new Mock<IBuyView>();

            mockBuyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<IPaymentMethod>>()))
                .Returns(requestedPaymentMethodId);

            var paymentUseCase = new PaymentUseCase(
                _application,
                mockBuyView.Object,
                listOfPaymentAlgorithm,
                _listOfPaymentMethods
            );

            Assert.Throws<FormatException>(() => paymentUseCase.Execute(requestedPrice));
        }
    }
}
