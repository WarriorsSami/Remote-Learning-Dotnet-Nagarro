using VendingMachine.Business.CustomExceptions.LoginUseCaseExceptions;
using VendingMachine.Domain.Business.IServices;

namespace VendingMachine.Business.Services;

public class AuthenticationService : IAuthenticationService
{
    public bool IsUserAuthenticated { get; set; }

    public void Login(string password)
    {
        if (password == "super")
            IsUserAuthenticated = true;
        else
            throw new InvalidCredentialsException("Invalid password");
    }

    public void Logout()
    {
        IsUserAuthenticated = false;
    }
}