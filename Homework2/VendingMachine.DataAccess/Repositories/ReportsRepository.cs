using System;
using System.IO;
using VendingMachine.Domain.Business.IFactories;
using VendingMachine.Domain.DataAccess.IRepositories;

namespace VendingMachine.DataAccess.Repositories;

internal class ReportsRepository : IReportsRepository
{
    private const string RootDirectoryPath = "Data";
    private readonly ISerializerFactory _serializerFactory;

    public ReportsRepository(ISerializerFactory serializerFactory)
    {
        _serializerFactory =
            serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
    }

    public void Add<TReport>(TReport report)
    {
        var filename = $"{typeof(TReport).Name} - {DateTime.Now:yyyy MM dd HHmmss}";
        var path = Path.Combine(RootDirectoryPath, $"{typeof(TReport).Name}s", filename);
        _serializerFactory.Serialize(report, path);
    }
}
