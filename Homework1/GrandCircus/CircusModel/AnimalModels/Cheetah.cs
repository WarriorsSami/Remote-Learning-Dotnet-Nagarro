namespace GrandCircus.CircusModel.AnimalModels
{
    public class Cheetah: AnimalBase
    {
        public Cheetah(string name, string speciesName) : base(name, speciesName)
        {
        }

        public override string MakeSound()
        {
            return "Usain Bolt screaming in the distance";
        }
    }
}