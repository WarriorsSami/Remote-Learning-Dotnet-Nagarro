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
                        arrayOfLetters.Add(new ALetter(randomLetter));
                        break;
                    case 'B':
                        arrayOfLetters.Add(new BLetter(randomLetter));
                        break;
                    case 'C':
                        arrayOfLetters.Add(new CLetter(randomLetter));
                        break;
                    case 'D':
                        arrayOfLetters.Add(new DLetter(randomLetter));
                        break;
                    case 'E':
                        arrayOfLetters.Add(new ELetter(randomLetter));
                        break;
                }
            }

            stopwatch.Start();
            foreach (var letter in arrayOfLetters)
            {
                switch (letter)
                {
                    case ALetter a:
                        a.Name = "A";
                        break;
                    case BLetter b:
                        b.Name = "B";
                        break;
                    case CLetter c:
                        c.Name = "C";
                        break;
                    case DLetter d:
                        d.Name = "D";
                        break;
                    case ELetter e:
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