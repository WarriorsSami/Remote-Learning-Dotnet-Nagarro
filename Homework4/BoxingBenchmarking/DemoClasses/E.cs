using System;

namespace BoxingBenchmarking.DemoClasses
{
    internal class E: ILetter
    {
        
        public E(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}