using System;

namespace BoxingBenchmarking.DemoClasses
{
    internal class D: ILetter
    {
        public D(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}