namespace GrandCircus.CircusModel.AnimalModels
{
    public class Camel: AnimalBase
    {
        public Camel(string name, string specieName) : base(name, specieName)
        {
        }

        public override string MakeSound()
        {
            return "**grunt**";
        }
    }
}