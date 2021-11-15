namespace GrandCircus.CircusModel
{
    public abstract class AnimalBase: IAnimal
    {
        public string SpeciesName { get; }
        public string Name { get; }
        
        protected AnimalBase(string name, string speciesName)
        {
            Name = name;
            SpeciesName = speciesName;
        }

        public abstract string MakeSound();
    }
}