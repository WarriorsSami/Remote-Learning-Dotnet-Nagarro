using Autofac;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.Presentation;
using VendingMachine.Presentation.Commands;

namespace VendingMachine
{
    public class UseCaseFactory : IUseCaseFactory
    {
        // private readonly ILifetimeScope _lifetimeScope;

        public T Create<T>() where T : IUseCase
        {
            var container = ContainerConfig.Build();
            using var scope = container.BeginLifetimeScope();
            if (typeof(T) == typeof(BuyUseCase))
            {
                return scope.Resolve<T>(
                    new TypedParameter(typeof(ICommand), scope.Resolve<PayCommand>())
                );
            }
            return scope.Resolve<T>();
        }
    }
}
