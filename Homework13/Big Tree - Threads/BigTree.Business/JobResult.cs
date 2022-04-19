using System;

namespace iQuest.BigTree.Business
{
    public class JobResult
    {
        public Node Tree { get; set; }

        public int NodeCount => Tree?.CountNodes() ?? 0;

        public TimeSpan ElapsedTime { get; set; }
    }
}