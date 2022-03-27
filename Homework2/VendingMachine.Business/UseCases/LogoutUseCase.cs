﻿using VendingMachine.Domain.Business;
using VendingMachine.Domain.Business.IUseCases;

namespace VendingMachine.Business.UseCases
{
    internal class LogoutUseCase : IUseCase
    {
        public void Execute(params object[] args)
        {
            var application = (IVendingMachineApplication)args[0];
            application.UserIsLoggedIn = false;
        }
    }
}