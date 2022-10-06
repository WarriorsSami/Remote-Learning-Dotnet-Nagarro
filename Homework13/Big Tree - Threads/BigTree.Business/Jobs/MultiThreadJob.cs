using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using iQuest.BigTree.ThirdPartyLibrary;

namespace iQuest.BigTree.Business.Jobs
{
    internal class MultiThreadJob : IJob
    {
        private readonly List<Thread> _threads = new List<Thread>();
        private readonly Mutex _mutex = new Mutex();
        private Node _tree;
        public int LevelCount { get; set; }

        public string Description { get; } = "Multi thread generation";

        public JobResult Execute()
        {
            TimeSpan elapsedTime = MeasureExecutionTime(
                () =>
                {
                    _tree = GenerateNode(LevelCount - 1);
                }
            );
            
            foreach (var thread in _threads)
            {
                thread.Join();
            }

            return new JobResult { Tree = _tree, ElapsedTime = elapsedTime };
        }

        private static Thread StartNewThread(Action action)
        {
            var t = new Thread(new ThreadStart(action));
            t.Start();
            
            return t;
        }
        
        private Node GenerateNode(int descendentLevelCount)
        {
            var node = new Node
            {
                Values = default
            };

            _threads.Add(StartNewThread(() =>
            {
                _mutex.WaitOne();
                node.Values = ThirdPartyCalculator.Calculate();
                _mutex.ReleaseMutex();
            }));
            
            if (descendentLevelCount > 0)
            {
                node.LeftNode = GenerateNode(descendentLevelCount - 1);
                node.RightNode = GenerateNode(descendentLevelCount - 1);
            }

            return node;
        }

        private static TimeSpan MeasureExecutionTime(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            return stopwatch.Elapsed;
        }
    }
}
