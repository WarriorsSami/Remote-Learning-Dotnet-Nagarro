namespace GrandCircus.CircusModel.AnimalModels
{
    public class Wolf: AnimalBase
    {
        public Wolf(string name, string speciesName) : base(name, speciesName)
        {
        }

        public override string MakeSound()
        {
            return "aaaaauuuuuuuuu";
        }
    }
}