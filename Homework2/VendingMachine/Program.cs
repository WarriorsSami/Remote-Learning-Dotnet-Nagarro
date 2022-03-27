using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using VendingMachine;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Presentation;
using VendingMachine.Presentation.Commands;

try
{
    using var context = ContainerConfig.Build().BeginLifetimeScope();

    var app = context.Resolve<IVendingMachineApplication>();
    var commands = context.Resolve<IEnumerable<ICommand>>().Where(c => c is not PayCommand);
    app.AddRangeCommand(commands);

    app.Run();
}
catch (Exception ex)
{
    DisplayError(ex);
    Pause();
}

static void DisplayError(Exception ex)
{
    var oldColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex);
    Console.ForegroundColor = oldColor;
}

static void Pause()
{
    Console.ReadKey(true);
}
