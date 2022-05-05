using System;
using System.Linq;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Dtos.Reports;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Business.UseCases;

internal class SalesReportUseCase : IUseCase
{
    private readonly IReportsRepository _reportsRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IReportsView _reportsView;

    private string _filePath = "Sales Report";

    public SalesReportUseCase(
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
        var sales = _saleRepository.Get(timeInterval);
        var salesReport = new SalesReportDocument { Sales = sales.ToArray() };

        _reportsRepository.Add(salesReport, ref _filePath);
        _reportsView.DisplaySuccessMessage("Sales", _filePath);
    }
}
