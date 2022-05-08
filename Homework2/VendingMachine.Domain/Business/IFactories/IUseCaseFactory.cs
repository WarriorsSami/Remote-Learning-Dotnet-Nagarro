using VendingMachine.Domain.Business.IUseCases;

namespace VendingMachine.Domain.Business.IFactories;

public interface IUseCaseFactory
{
    T Create<T>() where T : IUseCase;
}
