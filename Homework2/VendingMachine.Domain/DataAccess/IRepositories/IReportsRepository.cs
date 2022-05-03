namespace VendingMachine.Domain.DataAccess.IRepositories;
public interface IReportsRepository
{
    void Add<TReport>(TReport report);
}
