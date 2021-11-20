namespace GrandCircus.CircusModel.AnimalModels
{
    public class Elephant: AnimalBase
    {
        public Elephant(string name, string specieName) : base(name, specieName)
        {
        }

        public override string MakeSound()
        {
            return "bahruuuuuuhhhhaaaaa";
        }
    }
}