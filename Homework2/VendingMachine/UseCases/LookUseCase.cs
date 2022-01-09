using VendingMachine.Interfaces.IRepositories;
using VendingMachine.Interfaces.IUseCases;
using VendingMachine.PresentationLayer;
using VendingMachine.Repositories;

namespace VendingMachine.UseCases
{
    internal class LookUseCase: IUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly ShelfView _shelfView;

        public string Name => "display";
        public string Description => "Display the list of available products stored in the vending machine";
        public bool CanExecute => true;
        
        public LookUseCase(ShelfView shelfView, IProductRepository productRepository)
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
