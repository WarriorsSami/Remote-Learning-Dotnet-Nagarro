using System;
using System.IO;
using VendingMachine.Domain.Business.IFactories;
using VendingMachine.Domain.DataAccess.IRepositories;

namespace VendingMachine.DataAccess.Repositories;

internal class ReportsRepository : IReportsRepository
{
    // TODO: Change to a proper path retrieval
    private readonly string _rootDirectoryPath =
        $"{Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent}\\Data";
    private readonly ISerializerFactory _serializerFactory;

    public ReportsRepository(ISerializerFactory serializerFactory)
    {
        _serializerFactory =
            serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
    }

    public void Add<TReport>(TReport report, out string filePath) where TReport : class
    {
        var file = $"{typeof(TReport).Name} - {DateTime.Now:yyyy MM dd HHmmss}";
        filePath = Path.Combine(_rootDirectoryPath, $"{typeof(TReport).Name}s", file);
        _serializerFactory.Serialize(report, ref filePath);
    }
}
