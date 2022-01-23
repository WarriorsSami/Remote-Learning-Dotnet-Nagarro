using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Business.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.Business.CustomExceptions.LoginUseCaseExceptions;
using VendingMachine.Business.CustomExceptions.PaymentUseCaseExceptions;
using VendingMachine.Business.Interfaces;
using VendingMachine.Business.Interfaces.IPresentationLayer;
using VendingMachine.Business.Interfaces.IUseCases;

namespace VendingMachine.Business
{
    internal class VendingMachineApplication: IVendingMachineApplication
    {
        private readonly List<IUseCase> _useCases;
        private readonly IMainDisplay _mainDisplay;

        private bool _turnOffWasRequested;

        public bool UserIsLoggedIn { get; set; }

        public VendingMachineApplication(List<IUseCase> useCases, IMainDisplay mainDisplay)
        {
            _useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            _mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
        }

        public void Run()
        {
            _turnOffWasRequested = false;

            while (!_turnOffWasRequested)
            {
                var availableUseCases = _useCases
                    .Where(x => x.CanExecute);

                var useCase = _mainDisplay.ChooseCommand(availableUseCases);
                try
                {
                    useCase.Execute();
                }
                catch (InvalidCredentialsException e)
                {
                    _mainDisplay.DisplayError(e);
                    _mainDisplay.Pause();
                }
                catch (ProductNotFoundException e)
                {
                    _mainDisplay.DisplayError(e);
                    _mainDisplay.Pause();
                }
                catch (ProductOutOfStockException e)
                {
                    _mainDisplay.DisplayError(e);
                    _mainDisplay.Pause();
                }
                catch (CancelOrderException e)
                {
                    _mainDisplay.DisplayError(e);
                    _mainDisplay.Pause();
                }
                catch (InvalidPaymentMethodIdException e)
                {
                    _mainDisplay.DisplayError(e);
                    _mainDisplay.Pause();
                }
                catch (InvalidCreditCardIdException e)
                {
                    _mainDisplay.DisplayError(e);
                    _mainDisplay.Pause();
                }
                catch (FormatException e)
                {
                    _mainDisplay.DisplayError(e);
                    _mainDisplay.Pause();
                }
                catch (Exception e)
                {
                    _mainDisplay.DisplayError(e);
                    _mainDisplay.Pause();
                }
            }
        }

        public void TurnOff()
        {
            _turnOffWasRequested = true;
        }
    }
}