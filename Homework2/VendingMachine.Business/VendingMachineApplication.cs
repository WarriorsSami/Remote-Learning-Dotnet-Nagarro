using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using VendingMachine.Business.CustomExceptions.BuyUseCaseExceptions;
using VendingMachine.Business.CustomExceptions.LoginUseCaseExceptions;
using VendingMachine.Business.CustomExceptions.PaymentUseCaseExceptions;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Presentation.ICommands;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Business;

internal class VendingMachineApplication : IVendingMachineApplication
{
    private readonly ILog _logger;
    private readonly List<ICommand> _commands;
    private readonly IMainDisplay _mainDisplay;
    private readonly ITurnOffService _turnOffService;

    public VendingMachineApplication(
        IEnumerable<ICommand> commands,
        IMainDisplay mainDisplay,
        ITurnOffService turnOffService,
        ILog logger
    )
    {
        _commands = commands.ToList();
        _mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
        _turnOffService = turnOffService ?? throw new ArgumentNullException(nameof(turnOffService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void Run()
    {
        var message = "Application has been started";
        _logger.Info(message);

        _turnOffService.Initialize();
        while (!_turnOffService.TurnOffRequested)
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

                message =
                    $"Message: {e.Message} -> StackTrace: {e.StackTrace} (InnerException: {e.InnerException?.Message})";
                _logger.Error(message);

                DisplayBase.Pause();
            }
            catch (ProductNotFoundException e)
            {
                DisplayBase.DisplayError(e);

                message =
                    $"Message: {e.Message} -> StackTrace: {e.StackTrace} (InnerException: {e.InnerException?.Message})";
                _logger.Error(message);

                DisplayBase.Pause();
            }
            catch (ProductOutOfStockException e)
            {
                DisplayBase.DisplayError(e);

                message =
                    $"Message: {e.Message} -> StackTrace: {e.StackTrace} (InnerException: {e.InnerException?.Message})";
                _logger.Error(message);

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

                message =
                    $"Message: {e.Message} -> StackTrace: {e.StackTrace} (InnerException: {e.InnerException?.Message})";
                _logger.Error(message);

                DisplayBase.Pause();
            }
            catch (InvalidCreditCardIdException e)
            {
                DisplayBase.DisplayError(e);

                message =
                    $"Message: {e.Message} -> StackTrace: {e.StackTrace} (InnerException: {e.InnerException?.Message})";
                _logger.Error(message);

                DisplayBase.Pause();
            }
            catch (FormatException e)
            {
                DisplayBase.DisplayError(e);

                message =
                    $"Message: {e.Message} -> StackTrace: {e.StackTrace} (InnerException: {e.InnerException?.Message})";
                _logger.Error(message);

                DisplayBase.Pause();
            }
            catch (ArgumentNullException e)
            {
                DisplayBase.DisplayError(e);

                message =
                    $"Message: {e.Message} -> StackTrace: {e.StackTrace} (InnerException: {e.InnerException?.Message})";
                _logger.Error(message);

                DisplayBase.Pause();
            }
            catch (OverflowException e)
            {
                DisplayBase.DisplayError(e);

                message =
                    $"Message: {e.Message} -> StackTrace: {e.StackTrace} (InnerException: {e.InnerException?.Message})";
                _logger.Error(message);

                DisplayBase.Pause();
            }
            catch (Exception e)
            {
                DisplayBase.DisplayError(e);

                message =
                    $"Message: {e.Message} -> StackTrace: {e.StackTrace} (InnerException: {e.InnerException?.Message})";
                _logger.Error(message);

                DisplayBase.Pause();
            }
        }
    }
}
