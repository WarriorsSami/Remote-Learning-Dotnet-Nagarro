using System;

namespace BoxingBenchmarking.DemoClasses
{
    internal class C: ILetter
    {
        public C(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}