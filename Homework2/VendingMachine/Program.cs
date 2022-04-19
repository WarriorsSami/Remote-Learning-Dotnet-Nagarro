using System;
using Autofac;
using VendingMachine;
using VendingMachine.Domain.Business;

try
{
    using var context = ContainerConfig.Build().BeginLifetimeScope();
    var app = context.Resolve<IVendingMachineApplication>();

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
