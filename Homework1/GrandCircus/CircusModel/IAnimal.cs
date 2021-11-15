namespace GrandCircus.CircusModel
{
    public interface IAnimal
    {
        string SpeciesName { get; }
        string Name { get; }
        
        string MakeSound();
    }
}