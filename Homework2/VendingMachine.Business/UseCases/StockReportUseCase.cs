using System;
using System.Linq;
using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Dtos.Reports;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Business.UseCases;

internal class StockReportUseCase : IUseCase
{
    private readonly IReportsRepository _reportsRepository;
    private readonly IProductRepository _productRepository;
    private readonly IReportsView _reportsView;

    private string _filePath = "Stock Report";

    public StockReportUseCase(
        IProductRepository productRepository,
        IReportsView reportsView,
        IReportsRepository reportsRepository
    )
    {
        _productRepository =
            productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _reportsView = reportsView ?? throw new ArgumentNullException(nameof(reportsView));
        _reportsRepository =
            reportsRepository ?? throw new ArgumentNullException(nameof(reportsRepository));
    }

    public void Execute(params object[] args)
    {
        var products = _productRepository.GetAll();
        var stockReport = new StockReportDocument { Products = products.ToArray() };

        _reportsRepository.Add(stockReport, ref _filePath);
        _reportsView.DisplaySuccessMessage("Stock", _filePath);
    }
}
