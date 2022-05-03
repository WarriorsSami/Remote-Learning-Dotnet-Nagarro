namespace VendingMachine.Domain.DataAccess.IRepositories;
public interface IReportsRepository
{
    void Add<TReport>(TReport report, out string filePath) where TReport : class;
}
