using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace iQuest.OneHundred.Business.Jobs
{
    internal class SemaphoreJob : IJob
    {
        private readonly Semaphore _pool = new Semaphore(0, 5);
        private long _value;
        public ushort ThreadCount { get; set; }
        public ulong IncrementCount { get; set; }
        public string Description { get; } =
            "Incrementing the value using semaphore and interlocked";

        public JobResult Execute()
        {
            _value = 0;
            TimeSpan elapsedTime = MeasureExecutionTime(RunAllThreads);

            return new JobResult { Value = _value, ElapsedTime = elapsedTime };
        }

        private void RunAllThreads()
        {
            List<Thread> threads = Enumerable
                .Range(0, ThreadCount)
                .Select(x => StartNewThread())
                .ToList();

            _pool.Release(5);

            foreach (Thread thread in threads)
                thread.Join();
        }

        private Thread StartNewThread()
        {
            Thread thread = new Thread(
                o =>
                {
                    _pool.WaitOne();
                    for (ulong i = 0; i < IncrementCount; i++)
                        Interlocked.Increment(ref _value);
                    _pool.Release();
                }
            );

            thread.Start();

            return thread;
        }

        private static TimeSpan MeasureExecutionTime(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            return stopwatch.Elapsed;
        }
    }
}
