using System;
using System.Diagnostics;
using System.Threading.Tasks;
using iQuest.BigTree.ThirdPartyLibrary;

namespace iQuest.BigTree.Business.Jobs
{
    internal class MultiTaskJob : IJob
    {
        private Node _tree;
        public int LevelCount { get; set; }

        public string Description { get; } = "Multi task generation";

        public JobResult Execute()
        {
            TimeSpan elapsedTime = MeasureExecutionTime(
                () =>
                {
                    _tree = GenerateNode(LevelCount - 1);
                }
            );
            Task.WhenAll();

            return new JobResult { Tree = _tree, ElapsedTime = elapsedTime };
        }

        private static Node GenerateNode(int descendentLevelCount)
        {
            Node node = new Node
            {
                Values = Task.Run(ThirdPartyCalculator.Calculate).Result
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
