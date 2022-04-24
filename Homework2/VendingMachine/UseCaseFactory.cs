using System;
using Autofac;
using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.Presentation.ICommands;
using VendingMachine.Presentation.Commands;

namespace VendingMachine
{
    public class UseCaseFactory : IUseCaseFactory
    {
        private readonly ILifetimeScope _lifetimeScope;
        
        public UseCaseFactory(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
        }

        public T Create<T>() where T : IUseCase
        {
            if (typeof(T) == typeof(BuyUseCase))
            {
                return _lifetimeScope.Resolve<T>(
                    new TypedParameter(typeof(ICommand), _lifetimeScope.Resolve<PayCommand>())
                );
            }
            return _lifetimeScope.Resolve<T>();
        }
    }
}
