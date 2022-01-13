namespace BoxingBenchmarking.DemoClasses
{
    internal class ALetter: ILetter
    {
        public ALetter(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}