using System;
using System.Diagnostics;
using iQuest.BigTree.ThirdPartyLibrary;

namespace iQuest.BigTree.Business.Jobs
{
    internal class SingleThreadJob : IJob
    {
        public int LevelCount { get; set; }

        public string Description { get; } = "Single thread generation";

        public JobResult Execute()
        {
            Node tree = null;

            TimeSpan elapsedTime = MeasureExecutionTime(() => { tree = GenerateNode(LevelCount - 1); });

            return new JobResult
            {
                Tree = tree,
                ElapsedTime = elapsedTime
            };
        }

        private static Node GenerateNode(int descendentLevelCount)
        {
            Node node = new Node
            {
                Values = ThirdPartyCalculator.Calculate()
            };

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