namespace VendingMachine.Domain.Business.IFactories;

public interface ISerializerFactory
{
   void Serialize<TReport>(TReport report, string fileName); 
}