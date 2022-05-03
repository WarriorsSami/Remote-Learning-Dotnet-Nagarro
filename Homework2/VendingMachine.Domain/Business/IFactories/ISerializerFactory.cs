namespace VendingMachine.Domain.Business.IFactories;

public interface ISerializerFactory
{
   void Serialize<TReport>(TReport report, ref string filePath) where TReport: class; 
}