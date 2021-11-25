using System;
using VendingMachine.Data;
using VendingMachine.PresentationLayer;

namespace VendingMachine.UseCases
{
    internal class LookUseCase: IUseCase
    {
        private readonly ProductRepository _productRepository;
        private readonly ShelfView _shelfView;

        public string Name => "display";
        public string Description => "Display the list of available products stored in the vending machine";
        public bool CanExecute => true;
        
        public LookUseCase(ShelfView shelfView)
        {
            _shelfView = shelfView;
            _productRepository = new ProductRepository();
        }
        
        public void Execute()
        {
            _shelfView.DisplayProducts(_productRepository.GetAll());
        }
    }
}
