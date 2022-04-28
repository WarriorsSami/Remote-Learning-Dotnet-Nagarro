namespace VendingMachine.Domain.Business.IServices;

public interface IAuthenticationService
{
    bool IsUserAuthenticated { get; set; }
    void Login(string password);
    void Logout();
}