namespace GrandCircus.CircusModel.AnimalModels
{
    public class Kakadu: AnimalBase
    {
        public Kakadu(string name, string speciesName) : base(name, speciesName)
        {
        }

        public override string MakeSound()
        {
            return "**squawk**";
        }
    }
}