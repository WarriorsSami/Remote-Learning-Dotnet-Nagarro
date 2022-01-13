namespace BoxingBenchmarking.DemoClasses
{
    internal class DLetter: ILetter
    {
        public DLetter(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}