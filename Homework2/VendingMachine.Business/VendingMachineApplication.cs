using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Business.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.Business.CustomExceptions.LoginUseCaseExceptions;
using VendingMachine.Business.CustomExceptions.PaymentUseCaseExceptions;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Presentation;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Business
{
    internal class VendingMachineApplication : IVendingMachineApplication
    {
        private readonly List<ICommand> _commands = new();
        private readonly IMainDisplay _mainDisplay;

        private bool _turnOffWasRequested;

        public bool UserIsLoggedIn { get; set; }

        public VendingMachineApplication(IMainDisplay mainDisplay)
        {
            _mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
        }

        public void AddRangeCommand(IEnumerable<ICommand> commands)
        {
            if (commands == null)
                throw new ArgumentNullException(nameof(commands));

            _commands.AddRange(commands);
        }

        public void Run()
        {
            _turnOffWasRequested = false;

            while (!_turnOffWasRequested)
            {
                var availableCommands = _commands.Where(x => x.CanExecute);

                var command = _mainDisplay.ChooseCommand(availableCommands);
                try
                {
                    command.Execute();
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
