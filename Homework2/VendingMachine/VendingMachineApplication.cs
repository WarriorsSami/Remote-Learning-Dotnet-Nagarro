using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.CustomExceptions.LoginUseCaseExceptions;
using VendingMachine.PresentationLayer;

namespace VendingMachine
{
    public class VendingMachineApplication
    {
        private readonly List<IUseCase> _useCases;
        private readonly MainDisplay _mainDisplay;

        private bool _turnOffWasRequested;

        public bool UserIsLoggedIn { get; set; }

        public VendingMachineApplication(List<IUseCase> useCases, MainDisplay mainDisplay)
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
                    Program.DisplayError(e);
                    Program.Pause();
                }
                catch (ProductNotFoundException e)
                {
                    Program.DisplayError(e);
                    Program.Pause();
                }
                catch (ProductOutOfStockException e)
                {
                    Program.DisplayError(e);
                    Program.Pause();
                }
                catch (CancelOrderException e)
                {
                    Program.DisplayError(e);
                    Program.Pause();
                }
            }
        }

        public void TurnOff()
        {
            _turnOffWasRequested = true;
        }
    }
}