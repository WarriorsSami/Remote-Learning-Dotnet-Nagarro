namespace GrandCircus.CircusModel.AnimalModels
{
    public class Camel: AnimalBase
    {
        public Camel(string name, string speciesName) : base(name, speciesName)
        {
        }

        public override string MakeSound()
        {
            return "**grunt**";
        }
    }
}