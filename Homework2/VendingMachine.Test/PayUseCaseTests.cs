using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using VendingMachine.Business.CustomExceptions.PaymentUseCaseExceptions;
using VendingMachine.Business.Helpers.Payment;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business.IHelpersPayment;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Presentation.IViews;
using VendingMachine.Domain.Presentation.IViews.IPaymentTerminals;

namespace VendingMachine.Test;

internal class PayUseCaseTests
{
    private readonly ICardValidityAlgorithm _cardValidityAlgorithm;

    private readonly IEnumerable<IPaymentMethod> _listOfPaymentMethods;

    private readonly Mock<ISaleRepository> _saleRepositoryMock;

    private readonly Product _product;

    public PayUseCaseTests()
    {
        _cardValidityAlgorithm = new LuhnCardValidator();
        _listOfPaymentMethods = new List<IPaymentMethod>
        {
            new CashPaymentMethod(),
            new CreditCardPaymentMethod()
        };
        _saleRepositoryMock = new Mock<ISaleRepository>();
        _saleRepositoryMock.Setup(x => x.Add(It.IsAny<Sale>())).Verifiable();
        _product = new Product
        {
            ColumnId = 1,
            Name = "Fanta",
            Price = 1.5m,
            Quantity = 10
        };
    }

    [Test]
    public void NotHavingThrown_WhenSuccessfulCashPaymentAttemptIsMade()
    {
        const int requestedPaymentMethodId = 0;
        const decimal requestedPrice = 10.0m;
        const decimal requestedChange = 8.0m;

        var mockCardValidator = new Mock<ICardValidityAlgorithm>();
        var mockCashTerminal = new Mock<ICashTerminal>();
        var mockCreditCardTerminal = new Mock<ICardTerminal>();

        mockCashTerminal
            .SetupSequence(x => x.AskForMoney(It.IsAny<decimal>()))
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
            new CreditCardPaymentAlgorithm(mockCreditCardTerminal.Object, mockCardValidator.Object)
        };

        var mockBuyView = new Mock<IBuyView>();

        mockBuyView
            .Setup(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<IPaymentMethod>>()))
            .Returns(requestedPaymentMethodId);

        var paymentUseCase = new PayUseCase(
            mockBuyView.Object,
            listOfPaymentAlgorithm,
            _listOfPaymentMethods,
            _saleRepositoryMock.Object
        );

        _product.Price = requestedPrice;
        Assert.DoesNotThrow(() => paymentUseCase.Execute(_product));
    }

    [Test]
    public void HavingThrownInvalidPaymentMethodIdException_WhenAnInvalidPaymentMethodIdIsProvided()
    {
        const decimal requestedPrice = 10.0m;
        const int requestedPaymentMethodId = 2;

        var mockCardValidator = new Mock<ICardValidityAlgorithm>();
        var mockCashTerminal = new Mock<ICashTerminal>();
        var mockCreditCardTerminal = new Mock<ICardTerminal>();

        var listOfPaymentAlgorithm = new List<IPaymentAlgorithm>
        {
            new CashPaymentAlgorithm(mockCashTerminal.Object),
            new CreditCardPaymentAlgorithm(mockCreditCardTerminal.Object, mockCardValidator.Object)
        };

        var mockBuyView = new Mock<IBuyView>();

        mockBuyView
            .Setup(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<IPaymentMethod>>()))
            .Returns(requestedPaymentMethodId);

        var paymentUseCase = new PayUseCase(
            mockBuyView.Object,
            listOfPaymentAlgorithm,
            _listOfPaymentMethods,
            _saleRepositoryMock.Object
        );

        _product.Price = requestedPrice;
        Assert.Throws<InvalidPaymentMethodIdException>(
            () => paymentUseCase.Execute(_product)
        );
    }

    [Test]
    public void NotHavingThrown_WhenSuccessfulCreditCardPaymentAttemptIsMade()
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
            new CreditCardPaymentAlgorithm(mockCreditCardTerminal.Object, _cardValidityAlgorithm)
        };

        var mockBuyView = new Mock<IBuyView>();

        mockBuyView
            .Setup(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<IPaymentMethod>>()))
            .Returns(requestedPaymentMethodId);

        var paymentUseCase = new PayUseCase(
            mockBuyView.Object,
            listOfPaymentAlgorithm,
            _listOfPaymentMethods,
            _saleRepositoryMock.Object
        );

        _product.Price = requestedPrice;
        Assert.DoesNotThrow(() => paymentUseCase.Execute(_product));
    }

    [Test]
    public void HavingThrownInvalidCreditCardIdException_WhenAnInvalidCreditCardIdIsProvided()
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
            new CreditCardPaymentAlgorithm(mockCreditCardTerminal.Object, _cardValidityAlgorithm)
        };

        var mockBuyView = new Mock<IBuyView>();

        mockBuyView
            .Setup(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<IPaymentMethod>>()))
            .Returns(requestedPaymentMethodId);

        var paymentUseCase = new PayUseCase(
            mockBuyView.Object,
            listOfPaymentAlgorithm,
            _listOfPaymentMethods,
            _saleRepositoryMock.Object
        );

        _product.Price = requestedPrice;
        Assert.Throws<InvalidCreditCardIdException>(() => paymentUseCase.Execute(_product));
    }

    [Test]
    public void HavingThrownFormatException_WhenAnInvalidCreditCardIdFormatIsProvided()
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
            new CreditCardPaymentAlgorithm(mockCreditCardTerminal.Object, _cardValidityAlgorithm)
        };

        var mockBuyView = new Mock<IBuyView>();

        mockBuyView
            .Setup(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<IPaymentMethod>>()))
            .Returns(requestedPaymentMethodId);

        var paymentUseCase = new PayUseCase(
            mockBuyView.Object,
            listOfPaymentAlgorithm,
            _listOfPaymentMethods,
            _saleRepositoryMock.Object
        );

        _product.Price = requestedPrice;
        Assert.Throws<FormatException>(() => paymentUseCase.Execute(_product));
    }
}
