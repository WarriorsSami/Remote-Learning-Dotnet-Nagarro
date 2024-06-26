﻿using System;
using Autofac;
using VendingMachine.Domain.Business.IFactories;
using VendingMachine.Domain.Business.IUseCases;

namespace VendingMachine.Factories;

internal class UseCaseFactory : IUseCaseFactory
{
    private readonly ILifetimeScope _lifetimeScope;

    public UseCaseFactory(ILifetimeScope lifetimeScope)
    {
        _lifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
    }

    public T Create<T>() where T : IUseCase
    {
        return _lifetimeScope.Resolve<T>();
    }
}
