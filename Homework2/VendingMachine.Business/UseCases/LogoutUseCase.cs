using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.Business.IUseCases;

namespace VendingMachine.Business.UseCases
{
    internal class LogoutUseCase : IUseCase
    {
        public void Execute(params object[] args)
        {
            var authService = (IAuthenticationService)args[0];
            authService.Logout();
        }
    }
}
