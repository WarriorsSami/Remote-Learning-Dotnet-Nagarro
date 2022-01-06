namespace BoxingBenchmarking.DemoClasses
{
    internal class BLetter: ILetter
    {
        public BLetter(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}