namespace BoxingBenchmarking.DemoClasses
{
    internal class ELetter: ILetter
    {
        
        public ELetter(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}