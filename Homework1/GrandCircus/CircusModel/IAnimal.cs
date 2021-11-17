namespace GrandCircus.CircusModel
{
    public interface IAnimal
    {
        string SpecieName { get; }
        string Name { get; }
        
        string MakeSound();
    }
}