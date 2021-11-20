namespace GrandCircus.CircusModel
{
    public abstract class AnimalBase: IAnimal
    {
        public string SpecieName { get; }
        public string Name { get; }

        protected AnimalBase(string name, string specieName)
        {
            Name = name;
            SpecieName = specieName;
        }

        public abstract string MakeSound();
    }
}