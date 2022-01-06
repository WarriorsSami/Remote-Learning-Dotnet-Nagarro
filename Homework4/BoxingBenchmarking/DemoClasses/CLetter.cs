namespace BoxingBenchmarking.DemoClasses
{
    internal class CLetter: ILetter
    {
        public CLetter(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}