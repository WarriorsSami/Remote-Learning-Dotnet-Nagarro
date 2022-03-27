using VendingMachine.Domain.Business.IUseCases;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.Domain.Presentation.IViews;

namespace VendingMachine.Business.UseCases
{
    internal class LookUseCase: IUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IShelfView _shelfView;

        public LookUseCase(IShelfView shelfView, IProductRepository productRepository)
        {
            _shelfView = shelfView;
            _productRepository = productRepository;
        }
        
        public void Execute(params object[] args)
        {
            _shelfView.DisplayProducts(_productRepository.GetAll());
        }
    }
}
