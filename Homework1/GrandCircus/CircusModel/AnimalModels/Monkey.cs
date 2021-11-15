namespace GrandCircus.CircusModel.AnimalModels
{
    public class Monkey: AnimalBase
    {
        public Monkey(string name, string speciesName) : base(name, speciesName)
        {
        }

        public override string MakeSound()
        {
            return "ook oook oooook aaa";
        }
    }
}