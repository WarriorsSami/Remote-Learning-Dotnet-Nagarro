namespace GrandCircus.CircusModel.AnimalModels
{
    public class GrizzlyBear: AnimalBase
    {
        public GrizzlyBear(string name, string specieName) : base(name, specieName)
        {
        }

        public override string MakeSound()
        {
            return "mooooaaaaarrrr";
        }
    }
}