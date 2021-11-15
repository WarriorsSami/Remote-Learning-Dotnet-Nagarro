namespace GrandCircus.CircusModel.AnimalModels
{
    public class GrizzlyBear: AnimalBase
    {
        public GrizzlyBear(string name, string speciesName) : base(name, speciesName)
        {
        }

        public override string MakeSound()
        {
            return "mooooaaaaarrrr";
        }
    }
}