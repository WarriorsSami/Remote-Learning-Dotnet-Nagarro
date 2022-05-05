using VendingMachine.Domain.Business.IUseCases;

namespace VendingMachine.Domain.Business;

public interface IUseCaseFactory
{
    T Create<T>() where T : IUseCase;
}
