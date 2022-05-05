namespace VendingMachine.Domain.DataAccess.IRepositories;

public interface IReportsRepository
{
    void Add<TReport>(TReport report, ref string filePath) where TReport : class;
}
