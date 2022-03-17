using System.Collections.Generic;
using VendingMachine.Business.CustomExceptions.PaymentUseCaseExceptions;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Business.IHelpersPayment;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Business.UseCases
{
    internal class PaymentUseCase : IPaymentUseCase
    {
        private readonly IVendingMachineApplication _application;
        private readonly IBuyView _buyView;

        private readonly List<IPaymentAlgorithm> _paymentAlgorithms;
        private readonly List<IPaymentMethod> _paymentMethods;

        public string Name => "payment";
        public string Description => "Execute payment";
        public bool CanExecute => !_application.UserIsLoggedIn;

        public PaymentUseCase(
            IVendingMachineApplication application,
            IBuyView buyView,
            IEnumerable<IPaymentAlgorithm> paymentAlgorithms,
            IEnumerable<IPaymentMethod> paymentMethods
        )
        {
            _application = application;
            _buyView = buyView;
            _paymentAlgorithms = paymentAlgorithms as List<IPaymentAlgorithm>;
            _paymentMethods = paymentMethods as List<IPaymentMethod>;
        }

        public void Execute(decimal price)
        {
            var paymentMethodId = _buyView.AskForPaymentMethod(_paymentMethods);
            if (_paymentMethods.Find(p => p.Id == (PaymentMethodType)paymentMethodId) == null)
            {
                throw new InvalidPaymentMethodIdException("Invalid payment method id");
            }

            var paymentAlgorithm = _paymentAlgorithms.Find(
                p => p.Id == (PaymentMethodType)paymentMethodId
            );

            _buyView.DisplayCommand($"You have to pay {price}$!");
            _buyView.DisplayCommand(paymentAlgorithm?.Command);
            paymentAlgorithm?.Run(price);
        }
    }
}
