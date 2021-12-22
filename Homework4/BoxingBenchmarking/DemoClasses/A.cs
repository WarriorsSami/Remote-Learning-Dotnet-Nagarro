using System;

namespace BoxingBenchmarking.DemoClasses
{
    internal class A: ILetter
    {
        public A(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}