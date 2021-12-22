using System;
using System.Collections.Generic;
using System.Diagnostics;
using BoxingBenchmarking.DemoClasses;

namespace BoxingBenchmarking
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var arrayOfBounds = new long[]
            {
                10000,
                1000000,
                500000,
                25000000,
                30000000
            };

            foreach (var bound in arrayOfBounds)
            {
                Console.WriteLine("Benchmarking with bound of {0}", bound);
                ExecuteBenchmark(bound);
                Console.WriteLine();
            }
        }
        
        private static void ExecuteBenchmark(long letterBound)
        {
            var arrayOfLetters = new List<ILetter>();
            var stopwatch = new Stopwatch();
            
            for (var i = 0; i < letterBound; i++)
            {
                var randomLetter = (char)(65 + i % 5);
                switch (randomLetter)
                {
                    case 'A':
                        arrayOfLetters.Add(new A(randomLetter));
                        break;
                    case 'B':
                        arrayOfLetters.Add(new B(randomLetter));
                        break;
                    case 'C':
                        arrayOfLetters.Add(new C(randomLetter));
                        break;
                    case 'D':
                        arrayOfLetters.Add(new D(randomLetter));
                        break;
                    case 'E':
                        arrayOfLetters.Add(new E(randomLetter));
                        break;
                }
            }

            stopwatch.Start();
            foreach (var letter in arrayOfLetters)
            {
                switch (letter)
                {
                    case A a:
                        a.Name = "A";
                        break;
                    case B b:
                        b.Name = "B";
                        break;
                    case C c:
                        c.Name = "C";
                        break;
                    case D d:
                        d.Name = "D";
                        break;
                    case E e:
                        e.Name = "E";
                        break;
                }
            }
            stopwatch.Stop();
            
            Console.WriteLine($"Time to unbox {letterBound} letters: {stopwatch.ElapsedMilliseconds} ms");
            
            stopwatch.Restart();
            foreach (var letter in arrayOfLetters)
            {
                object unused = letter;
            }
            stopwatch.Stop();
            
            Console.WriteLine($"Time to box {letterBound} letters: {stopwatch.ElapsedMilliseconds} ms");
            
            arrayOfLetters.Clear();
        }
    }
}