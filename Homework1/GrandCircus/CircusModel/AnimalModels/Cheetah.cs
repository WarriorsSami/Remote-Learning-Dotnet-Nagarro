namespace GrandCircus.CircusModel.AnimalModels
{
    public class Cheetah: AnimalBase
    {
        public Cheetah(string name, string specieName) : base(name, specieName)
        {
        }

        public override string MakeSound()
        {
            return "Usain Bolt screaming in the distance";
        }
    }
}