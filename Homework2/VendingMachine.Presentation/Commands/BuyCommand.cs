using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Presentation;

namespace VendingMachine.Presentation.Commands 
{
   internal class BuyCommand : ICommand
   {
      private readonly IVendingMachineApplication _application;
      private readonly IUseCaseFactory _useCaseFactory;

      public BuyCommand(IVendingMachineApplication application, IUseCaseFactory useCaseFactory)
      {
         _application = application;
         _useCaseFactory = useCaseFactory;
      }

      public string Name => "buy";
      public string Description => "Buy & Pay for a product"; 
      public bool CanExecute => !_application.UserIsLoggedIn;
      
      public void Execute(params object[] args)
      {
         _useCaseFactory.Create<BuyUseCase>().Execute();
      }
   }
}