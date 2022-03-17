using System;
using System.Collections.Generic;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using VendingMachine.Business;
using VendingMachine.Business.Helpers.Payment;
using VendingMachine.Business.UseCases;
using VendingMachine.DataAccess.Repositories;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Business.IHelpersPayment;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Presentation.IViews;
using VendingMachine.Domain.Presentation.IViews.IPaymentTerminals;
using VendingMachine.Presentation.Views;
using VendingMachine.Presentation.Views.PaymentTerminals;

try
{
    var builder = new ContainerBuilder();

    builder.RegisterType<MainDisplay>().As<IMainDisplay>().InstancePerLifetimeScope();
    builder.RegisterType<BuyView>().As<IBuyView>().InstancePerLifetimeScope();
    builder.RegisterType<ShelfView>().As<IShelfView>().InstancePerLifetimeScope();

    builder.RegisterType<CashPaymentTerminal>().As<ICashTerminal>().InstancePerLifetimeScope();
    builder
        .RegisterType<CreditCardPaymentTerminal>()
        .As<ICardTerminal>()
        .InstancePerLifetimeScope();
    builder.RegisterType<CashPaymentAlgorithm>().As<IPaymentAlgorithm>().InstancePerLifetimeScope();
    builder
        .RegisterType<CreditCardPaymentAlgorithm>()
        .As<IPaymentAlgorithm>()
        .InstancePerLifetimeScope();
    builder.RegisterType<CashPaymentMethod>().As<IPaymentMethod>().InstancePerLifetimeScope();
    builder.RegisterType<CreditCardPaymentMethod>().As<IPaymentMethod>().InstancePerLifetimeScope();
    builder.RegisterType<LuhnCardValidator>().As<ICardValidityAlgorithm>().InstancePerLifetimeScope();

    var configuration = new ConfigurationBuilder()
        .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
        .Build();
    var connectionString = configuration.GetConnectionString("DefaultConnection");

    var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
    optionsBuilder.UseNpgsql(connectionString);
    var productContext = new ProductContext(optionsBuilder.Options);

    builder.RegisterInstance(productContext).As<ProductContext>().SingleInstance();
    builder
        .RegisterType<ProductPersistentRepository>()
        .As<IProductRepository>()
        .InstancePerLifetimeScope();

    builder
        .RegisterType<BuyUseCase>()
        .As<IUseCase>()
        .InstancePerLifetimeScope()
        .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
    builder.RegisterType<PaymentUseCase>().As<IPaymentUseCase>();
    builder
        .RegisterType<LookUseCase>()
        .As<IUseCase>()
        .InstancePerLifetimeScope()
        .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
    builder
        .RegisterType<LoginUseCase>()
        .As<IUseCase>()
        .InstancePerLifetimeScope()
        .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
    builder
        .RegisterType<LogoutUseCase>()
        .As<IUseCase>()
        .InstancePerLifetimeScope()
        .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
    builder
        .RegisterType<TurnOffUseCase>()
        .As<IUseCase>()
        .InstancePerLifetimeScope()
        .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

    builder
        .RegisterType<VendingMachineApplication>()
        .As<IVendingMachineApplication>()
        .InstancePerLifetimeScope()
        .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

    var container = builder.Build();
    using var context = container.BeginLifetimeScope();

    var app = context.Resolve<IVendingMachineApplication>();
    var useCases = context.Resolve<IEnumerable<IUseCase>>();
    app.AddRangeUseCase(useCases);

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
