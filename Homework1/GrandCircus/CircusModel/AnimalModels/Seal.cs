namespace GrandCircus.CircusModel.AnimalModels
{
    public class Seal: AnimalBase
    {
        public Seal(string name, string specieName) : base(name, specieName)
        {
        }

        public override string MakeSound()
        {
            return "**bark**";
        }
    }
}