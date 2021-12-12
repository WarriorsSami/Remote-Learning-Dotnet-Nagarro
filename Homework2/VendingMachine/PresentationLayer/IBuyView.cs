using VendingMachine.Models;

namespace VendingMachine.PresentationLayer
{
    internal interface IBuyView
    {
        void DisplayProduct(Product product);
        string AskForProductCode();
    }
}