using System;
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
using VendingMachine.Domain.Presentation;
using VendingMachine.Domain.Presentation.IViews;
using VendingMachine.Domain.Presentation.IViews.IPaymentTerminals;
using VendingMachine.Presentation.Commands;
using VendingMachine.Presentation.Views;
using VendingMachine.Presentation.Views.PaymentTerminals;

namespace VendingMachine
{
    public static class ContainerConfig
    {
        private static IContainer _container;
        
        public static IContainer Build()
        {
            if (_container != null)
                return _container;
            
            var builder = new ContainerBuilder();

            builder.RegisterType<MainDisplay>().As<IMainDisplay>().SingleInstance();
            builder.RegisterType<BuyView>().As<IBuyView>().SingleInstance();
            builder.RegisterType<ShelfView>().As<IShelfView>().SingleInstance();

            builder.RegisterType<CashPaymentTerminal>().As<ICashTerminal>().SingleInstance();
            builder.RegisterType<CreditCardPaymentTerminal>().As<ICardTerminal>().SingleInstance();
            builder.RegisterType<CashPaymentAlgorithm>().As<IPaymentAlgorithm>().SingleInstance();
            builder
                .RegisterType<CreditCardPaymentAlgorithm>()
                .As<IPaymentAlgorithm>()
                .SingleInstance();
            builder.RegisterType<CashPaymentMethod>().As<IPaymentMethod>().SingleInstance();
            builder.RegisterType<CreditCardPaymentMethod>().As<IPaymentMethod>().SingleInstance();
            builder.RegisterType<LuhnCardValidator>().As<ICardValidityAlgorithm>().SingleInstance();

            var configuration = new ConfigurationBuilder()
                .Add(
                    new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true }
                )
                .Build();
            var persistenceType = configuration.GetSection("PersistenceType").Value;

            switch (persistenceType)
            {
                case "Database":
                    var connectionString = configuration.GetConnectionString("DefaultConnection");
                    var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
                    optionsBuilder.UseNpgsql(connectionString);
                    var productContext = new ProductContext(optionsBuilder.Options);

                    builder.RegisterInstance(productContext).As<ProductContext>().SingleInstance();
                    builder
                        .RegisterType<ProductPersistentRepository>()
                        .As<IProductRepository>()
                        .SingleInstance();
                    break;
                case "InMemory":
                    builder
                        .RegisterType<ProductRepository>()
                        .As<IProductRepository>()
                        .SingleInstance();
                    break;
                default:
                    throw new Exception("Invalid persistence type");
            }

            builder.RegisterType<BuyCommand>().As<ICommand>().SingleInstance();
            builder.RegisterType<LookCommand>().As<ICommand>().SingleInstance();
            builder.RegisterType<PayCommand>().As<ICommand>().AsSelf().SingleInstance();
            builder.RegisterType<LoginCommand>().As<ICommand>().SingleInstance();
            builder.RegisterType<LogoutCommand>().As<ICommand>().SingleInstance();
            builder.RegisterType<TurnOffCommand>().As<ICommand>().SingleInstance();

            builder.RegisterType<UseCaseFactory>().As<IUseCaseFactory>().SingleInstance();

            builder.RegisterType<BuyUseCase>().As<IUseCase>().AsSelf().SingleInstance();
            builder.RegisterType<PayUseCase>().As<IUseCase>().AsSelf().SingleInstance();
            builder.RegisterType<LookUseCase>().As<IUseCase>().AsSelf().SingleInstance();
            builder.RegisterType<LoginUseCase>().As<IUseCase>().AsSelf().SingleInstance();
            builder.RegisterType<LogoutUseCase>().As<IUseCase>().AsSelf().SingleInstance();
            builder.RegisterType<TurnOffUseCase>().As<IUseCase>().AsSelf().SingleInstance();

            builder
                .RegisterType<VendingMachineApplication>()
                .As<IVendingMachineApplication>()
                .SingleInstance();

            _container = builder.Build();
            return _container;
        }
    }
}
