using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Business.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.Business.CustomExceptions.LoginUseCaseExceptions;
using VendingMachine.Business.CustomExceptions.PaymentUseCaseExceptions;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Business
{
    internal class VendingMachineApplication: IVendingMachineApplication
    {
        private readonly List<IUseCase> _useCases = new();
        private readonly IMainDisplay _mainDisplay;

        private bool _turnOffWasRequested;

        public bool UserIsLoggedIn { get; set; }

        public VendingMachineApplication(IMainDisplay mainDisplay)
        {
            _mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
        }
        
        public void AddUseCase(IUseCase useCase)
        {
            if (useCase == null)
                throw new ArgumentNullException(nameof(useCase));

            _useCases.Add(useCase);
        }
        
        public void AddRangeUseCase(IEnumerable<IUseCase> useCases)
        {
            if (useCases == null)
                throw new ArgumentNullException(nameof(useCases));

            _useCases.AddRange(useCases);
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
                    DisplayBase.DisplayError(e);
                    DisplayBase.Pause();
                }
                catch (ProductNotFoundException e)
                {
                    DisplayBase.DisplayError(e);
                    DisplayBase.Pause();
                }
                catch (ProductOutOfStockException e)
                {
                    DisplayBase.DisplayError(e);
                    DisplayBase.Pause();
                }
                catch (CancelOrderException e)
                {
                    DisplayBase.DisplayError(e);
                    DisplayBase.Pause();
                }
                catch (InvalidPaymentMethodIdException e)
                {
                    DisplayBase.DisplayError(e);
                    DisplayBase.Pause();
                }
                catch (InvalidCreditCardIdException e)
                {
                    DisplayBase.DisplayError(e);
                    DisplayBase.Pause();
                }
                catch (FormatException e)
                {
                    DisplayBase.DisplayError(e);
                    DisplayBase.Pause();
                }
                catch (Exception e)
                {
                    DisplayBase.DisplayError(e);
                    DisplayBase.Pause();
                }
            }
        }

        public void TurnOff()
        {
            _turnOffWasRequested = true;
        }
    }
}