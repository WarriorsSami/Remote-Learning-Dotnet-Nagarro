using VendingMachine.Business.Interfaces.IPresentationLayer;
using VendingMachine.Business.Interfaces.IRepositories;
using VendingMachine.Business.Interfaces.IUseCases;

namespace VendingMachine.Business.UseCases
{
    internal class LookUseCase: IUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IShelfView _shelfView;

        public string Name => "display";
        public string Description => "Display the list of available products stored in the vending machine";
        public bool CanExecute => true;
        
        public LookUseCase(IShelfView shelfView, IProductRepository productRepository)
        {
            _shelfView = shelfView;
            _productRepository = productRepository;
        }
        
        public void Execute()
        {
            _shelfView.DisplayProducts(_productRepository.GetAll());
        }
    }
}
