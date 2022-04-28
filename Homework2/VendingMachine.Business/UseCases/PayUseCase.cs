using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Business.CustomExceptions.PaymentUseCaseExceptions;
using VendingMachine.Domain.Business.IHelpersPayment;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Business.UseCases;

internal class PayUseCase : IUseCase
{
    private readonly IBuyView _buyView;

    private readonly IEnumerable<IPaymentAlgorithm> _paymentAlgorithms;
    private readonly IEnumerable<IPaymentMethod> _paymentMethods;

    public PayUseCase(
        IBuyView buyView,
        IEnumerable<IPaymentAlgorithm> paymentAlgorithms,
        IEnumerable<IPaymentMethod> paymentMethods
    )
    {
        _buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
        _paymentAlgorithms =
            paymentAlgorithms ?? throw new ArgumentNullException(nameof(paymentAlgorithms));
        _paymentMethods =
            paymentMethods ?? throw new ArgumentNullException(nameof(paymentMethods));
    }

    public void Execute(params object[] args)
    {
        var price = (decimal)args[0];
        var paymentMethodId = _buyView.AskForPaymentMethod(_paymentMethods);
        if (
            _paymentMethods.FirstOrDefault(p => p.Id == (PaymentMethodType)paymentMethodId)
            == null
        )
        {
            throw new InvalidPaymentMethodIdException("Invalid payment method id");
        }

        var paymentAlgorithm = _paymentAlgorithms.FirstOrDefault(
            p => p.Id == (PaymentMethodType)paymentMethodId
        );

        _buyView.DisplayCommand($"You have to pay {price}$!");
        _buyView.DisplayCommand(paymentAlgorithm?.Command);
        paymentAlgorithm?.Run(price);
    }
}