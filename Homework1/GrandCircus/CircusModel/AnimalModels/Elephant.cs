namespace GrandCircus.CircusModel.AnimalModels
{
    public class Elephant: AnimalBase
    {
        public Elephant(string name, string speciesName) : base(name, speciesName)
        {
        }

        public override string MakeSound()
        {
            return "bahruuuuuuhhhhaaaaa";
        }
    }
}