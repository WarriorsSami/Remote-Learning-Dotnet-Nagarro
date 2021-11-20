namespace GrandCircus.CircusModel.AnimalModels
{
    public class Wolf: AnimalBase
    {
        public Wolf(string name, string specieName) : base(name, specieName)
        {
        }

        public override string MakeSound()
        {
            return "aaaaauuuuuuuuu";
        }
    }
}