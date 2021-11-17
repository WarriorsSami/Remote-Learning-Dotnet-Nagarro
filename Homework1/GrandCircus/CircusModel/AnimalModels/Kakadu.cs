namespace GrandCircus.CircusModel.AnimalModels
{
    public class Kakadu: AnimalBase
    {
        public Kakadu(string name, string specieName) : base(name, specieName)
        {
        }

        public override string MakeSound()
        {
            return "**squawk**";
        }
    }
}