using System;

namespace BoxingBenchmarking.DemoClasses
{
    internal class B: ILetter
    {
        public B(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}