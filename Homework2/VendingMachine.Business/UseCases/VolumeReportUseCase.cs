using System;
using System.Linq;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Dtos.ReportDocuments;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Business.UseCases;

internal class VolumeReportUseCase : IUseCase
{
    private readonly IReportsRepository _reportsRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IReportsView _reportsView;

    private const string ReportName = "VolumeReportDocuments\\Volume Report";

    public VolumeReportUseCase(
        ISaleRepository saleRepository,
        IReportsView reportsView,
        IReportsRepository reportsRepository
    )
    {
        _saleRepository = saleRepository ?? throw new ArgumentNullException(nameof(saleRepository));
        _reportsView = reportsView ?? throw new ArgumentNullException(nameof(reportsView));
        _reportsRepository =
            reportsRepository ?? throw new ArgumentNullException(nameof(reportsRepository));
    }

    public void Execute(params object[] args)
    {
        var timeInterval = _reportsView.AskForTimeInterval();
        var productSales = _saleRepository.GetGroupedByProduct(timeInterval);
        var volumeReport = new VolumeReportDocument
        {
            StartTime = timeInterval.Start,
            EndTime = timeInterval.End,
            Sales = productSales.ToArray()
        };

        var filePath = ReportName;
        _reportsRepository.Add(volumeReport, ref filePath);
        _reportsView.DisplaySuccessMessage("Volume", filePath);
    }
}
