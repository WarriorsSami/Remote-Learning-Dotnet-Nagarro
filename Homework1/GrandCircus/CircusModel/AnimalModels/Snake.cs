namespace GrandCircus.CircusModel.AnimalModels
{
    public class Snake: AnimalBase
    {
        public Snake(string name, string speciesName) : base(name, speciesName)
        {
        }

        public override string MakeSound()
        {
            return "ssssssssssssssss";
        }
    }
}