namespace GrandCircus.CircusModel.AnimalModels
{
    public class Seal: AnimalBase
    {
        public Seal(string name, string speciesName) : base(name, speciesName)
        {
        }

        public override string MakeSound()
        {
            return "**bark**";
        }
    }
}