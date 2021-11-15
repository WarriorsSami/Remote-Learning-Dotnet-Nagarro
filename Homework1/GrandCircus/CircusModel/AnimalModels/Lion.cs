namespace GrandCircus.CircusModel.AnimalModels
{
    public class Lion: AnimalBase
    {
        public Lion(string name, string speciesName) : base(name, speciesName)
        {
        }

        public override string MakeSound()
        {
            return "roooooaaaarrrr";
        }
    }
}