namespace GrandCircus.CircusModel.AnimalModels
{
    public class Monkey: AnimalBase
    {
        public Monkey(string name, string specieName) : base(name, specieName)
        {
        }

        public override string MakeSound()
        {
            return "ook oook oooook aaa";
        }
    }
}