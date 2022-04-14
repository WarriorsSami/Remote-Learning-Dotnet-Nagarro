using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace iQuest.OneHundred.Business.Jobs
{
    internal class EventWaitHandleJob : IJob
    {
        private readonly EventWaitHandle _waitHandle = new AutoResetEvent(false);
        private long _value;
        public ushort ThreadCount { get; set; }
        public ulong IncrementCount { get; set; }
        public string Description { get; } = "Incrementing the value using event wait handle";

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

            _waitHandle.Set();
            
            foreach (Thread thread in threads)
                thread.Join();
        }

        private Thread StartNewThread()
        {
            Thread thread = new Thread(
                o =>
                {
                    _waitHandle.WaitOne();
                    for (ulong i = 0; i < IncrementCount; i++)
                        _value++;
                    _waitHandle.Set();
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
