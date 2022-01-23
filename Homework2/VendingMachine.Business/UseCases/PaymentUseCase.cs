using System.Collections.Generic;
using VendingMachine.Business.CustomExceptions.PaymentUseCaseExceptions;
using VendingMachine.Business.Helpers.Payment;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Interfaces.IHelpersPayment;
using VendingMachine.Business.Interfaces.IPresentationLayer;
using VendingMachine.Business.Interfaces.IRepositories;
using VendingMachine.Business.Interfaces.IUseCases;

namespace VendingMachine.Business.UseCases
{
    internal class PaymentUseCase: IPaymentUseCase
    {
        private readonly IVendingMachineApplication _application;
        private readonly IBuyView _buyView;
        
        private readonly List<IPaymentAlgorithm> _paymentAlgorithms;
        private readonly List<PaymentMethod> _paymentMethods;
        private readonly IPaymentRepository _paymentRepository;

        public string Name => "payment";
        public string Description => "Execute payment";
        public bool CanExecute => !_application.UserIsLoggedIn;
            
        public PaymentUseCase(IVendingMachineApplication application,
            IBuyView buyView,
            IPaymentRepository paymentRepository)
        {
            _application = application;
            _buyView = buyView;
            _paymentRepository = paymentRepository;
            _paymentAlgorithms = _paymentRepository.GetPaymentAlgorithms();
            _paymentMethods = _paymentRepository.GetPaymentMethods();
        }
        
        public void Execute(decimal price)
        {
            var paymentMethodId = _buyView.AskForPaymentMethod(_paymentMethods);
            if (_paymentMethods.Find(p =>
                p.Id == (PaymentMethodType)paymentMethodId) == null)
            {
                throw new InvalidPaymentMethodIdException("Invalid payment method id");
            }

            var paymentAlgorithm = _paymentAlgorithms.Find(p =>
                p.Id == (PaymentMethodType) paymentMethodId);
            
            _buyView.DisplayCommand($"You have to pay {price}$!");
            _buyView.DisplayCommand(paymentAlgorithm?.Command);
            paymentAlgorithm?.Run(price);
        }
    }
}