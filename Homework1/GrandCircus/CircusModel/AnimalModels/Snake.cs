namespace GrandCircus.CircusModel.AnimalModels
{
    public class Snake: AnimalBase
    {
        public Snake(string name, string specieName) : base(name, specieName)
        {
        }

        public override string MakeSound()
        {
            return "ssssssssssssssss";
        }
    }
}