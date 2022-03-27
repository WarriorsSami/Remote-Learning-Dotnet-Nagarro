using VendingMachine.Business.UseCases;
using VendingMachine.Domain.Business;
using VendingMachine.Domain.Presentation;

namespace VendingMachine.Presentation.Commands
{
    internal class LookCommand : ICommand
    {
        private readonly IVendingMachineApplication _application;
        private readonly IUseCaseFactory _useCaseFactory;

        public LookCommand(IVendingMachineApplication application, IUseCaseFactory useCaseFactory)
        {
            _application = application;
            _useCaseFactory = useCaseFactory;
        }

        public string Name => "display";
        public string Description =>
            "Display the list of available products stored in the vending machine";
        public bool CanExecute => true;

        public void Execute(params object[] args)
        {
            _useCaseFactory.Create<LookUseCase>().Execute();
        }
    }
}
