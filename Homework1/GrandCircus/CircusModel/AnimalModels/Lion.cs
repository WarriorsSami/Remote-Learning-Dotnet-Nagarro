namespace GrandCircus.CircusModel.AnimalModels
{
    public class Lion: AnimalBase
    {
        public Lion(string name, string specieName) : base(name, specieName)
        {
        }

        public override string MakeSound()
        {
            return "roooooaaaarrrr";
        }
    }
}