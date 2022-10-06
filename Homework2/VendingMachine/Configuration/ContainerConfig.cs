using System;
using System.Linq;
using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using VendingMachine.Business;
using VendingMachine.Business.Helpers.Payment;
using VendingMachine.Business.Services;
using VendingMachine.Business.UseCases;
using VendingMachine.DataAccess.Contexts;
using VendingMachine.DataAccess.Repositories;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Business.IFactories;
using VendingMachine.Domain.Business.IHelpersPayment;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Presentation.ICommands;
using VendingMachine.Domain.Presentation.IViews;
using VendingMachine.Domain.Presentation.IViews.IPaymentTerminals;
using VendingMachine.Factories;
using VendingMachine.Log4Net;
using VendingMachine.Presentation.Commands;
using VendingMachine.Presentation.Views;
using VendingMachine.Presentation.Views.PaymentTerminals;

namespace VendingMachine.Configuration;

public static class ContainerConfig
{
    public static IContainer Build()
    {
        var builder = new ContainerBuilder();

        builder.RegisterModule<Log4NetModule>();

        builder.RegisterType<MainDisplay>().As<IMainDisplay>().SingleInstance();
        builder.RegisterType<BuyView>().As<IBuyView>().SingleInstance();
        builder.RegisterType<ShelfView>().As<IShelfView>().SingleInstance();
        builder.RegisterType<SupplyProductView>().As<ISupplyProductView>().SingleInstance();
        builder.RegisterType<ReportsView>().As<IReportsView>().SingleInstance();

        builder.RegisterType<CashPaymentTerminal>().As<ICashTerminal>().SingleInstance();
        builder.RegisterType<CreditCardPaymentTerminal>().As<ICardTerminal>().SingleInstance();
        builder.RegisterType<CashPaymentAlgorithm>().As<IPaymentAlgorithm>().SingleInstance();
        builder.RegisterType<CreditCardPaymentAlgorithm>().As<IPaymentAlgorithm>().SingleInstance();
        builder.RegisterType<CashPaymentMethod>().As<IPaymentMethod>().SingleInstance();
        builder.RegisterType<CreditCardPaymentMethod>().As<IPaymentMethod>().SingleInstance();
        builder.RegisterType<LuhnCardValidator>().As<ICardValidityAlgorithm>().SingleInstance();

        var configuration = new ConfigurationBuilder()
            .Add(
                new JsonConfigurationSource
                {
                    Path = "Configuration\\appsettings.json",
                    ReloadOnChange = true
                }
            )
            .Build();
        var persistenceType = configuration.GetSection("PersistenceType").Value;

        switch (persistenceType)
        {
            case "Database":
                builder
                    .Register(
                        _ =>
                        {
                            return new ProductContextFactory().CreateDbContext(
                                new[] { configuration.GetConnectionString("DefaultConnection") }
                            );
                        }
                    )
                    .SingleInstance();
                builder
                    .RegisterType<ProductPersistentRepository>()
                    .As<IProductRepository>()
                    .SingleInstance();

                builder
                    .Register(
                        _ =>
                        {
                            return new SaleContextFactory().CreateDbContext(
                                new[] { configuration.GetConnectionString("DefaultConnection") }
                            );
                        }
                    )
                    .SingleInstance();
                builder
                    .RegisterType<SalePersistentRepository>()
                    .As<ISaleRepository>()
                    .SingleInstance();
                break;
            case "InMemory":
                builder
                    .RegisterType<ProductInMemoryRepository>()
                    .As<IProductRepository>()
                    .SingleInstance();

                builder
                    .RegisterType<SaleInMemoryRepository>()
                    .As<ISaleRepository>()
                    .SingleInstance();
                break;
            default:
                throw new Exception("Invalid persistence type");
        }

        var reportType = configuration.GetSection("ReportType").Value;
        if (new[] { "xml", "json" }.Contains(reportType))
        {
            builder
                .RegisterInstance(new SerializerConfiguration { Type = reportType })
                .As<SerializerConfiguration>()
                .SingleInstance();
        }
        else
        {
            throw new Exception("Invalid report type");
        }

        builder.RegisterType<ReportsRepository>().As<IReportsRepository>().SingleInstance();

        builder.RegisterType<BuyCommand>().As<ICommand>().SingleInstance();
        builder.RegisterType<LookCommand>().As<ICommand>().SingleInstance();
        builder.RegisterType<PayCommand>().As<IPayCommand>().AsSelf().SingleInstance();
        builder.RegisterType<LoginCommand>().As<ICommand>().SingleInstance();
        builder.RegisterType<LogoutCommand>().As<ICommand>().SingleInstance();
        builder.RegisterType<TurnOffCommand>().As<ICommand>().SingleInstance();
        builder.RegisterType<SupplyExistingProductCommand>().As<ICommand>().SingleInstance();
        builder.RegisterType<SupplyNewProductCommand>().As<ICommand>().SingleInstance();
        builder.RegisterType<StockReportCommand>().As<ICommand>().SingleInstance();
        builder.RegisterType<SalesReportCommand>().As<ICommand>().SingleInstance();
        builder.RegisterType<VolumeReportCommand>().As<ICommand>().SingleInstance();

        builder.RegisterType<UseCaseFactory>().As<IUseCaseFactory>().SingleInstance();
        builder.RegisterType<SerializerFactory>().As<ISerializerFactory>().SingleInstance();

        builder.RegisterType<BuyUseCase>().As<IUseCase>().AsSelf().SingleInstance();
        builder.RegisterType<PayUseCase>().As<IUseCase>().AsSelf().SingleInstance();
        builder.RegisterType<LookUseCase>().As<IUseCase>().AsSelf().SingleInstance();
        builder.RegisterType<LoginUseCase>().As<IUseCase>().AsSelf().SingleInstance();
        builder.RegisterType<LogoutUseCase>().As<IUseCase>().AsSelf().SingleInstance();
        builder.RegisterType<TurnOffUseCase>().As<IUseCase>().AsSelf().SingleInstance();
        builder
            .RegisterType<SupplyExistingProductUseCase>()
            .As<IUseCase>()
            .AsSelf()
            .SingleInstance();
        builder.RegisterType<SupplyNewProductUseCase>().As<IUseCase>().AsSelf().SingleInstance();
        builder.RegisterType<StockReportUseCase>().As<IUseCase>().AsSelf().SingleInstance();
        builder.RegisterType<SalesReportUseCase>().As<IUseCase>().AsSelf().SingleInstance();
        builder.RegisterType<VolumeReportUseCase>().As<IUseCase>().AsSelf().SingleInstance();

        builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
        builder.RegisterType<TurnOffService>().As<ITurnOffService>().SingleInstance();

        builder
            .RegisterType<VendingMachineApplication>()
            .As<IVendingMachineApplication>()
            .SingleInstance();

        return builder.Build();
    }
}
