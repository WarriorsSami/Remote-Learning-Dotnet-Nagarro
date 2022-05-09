using Autofac;
using VendingMachine.Configuration;
using VendingMachine.Domain.Business;

using var context = ContainerConfig.Build().BeginLifetimeScope();
var app = context.Resolve<IVendingMachineApplication>();

app.Run();
