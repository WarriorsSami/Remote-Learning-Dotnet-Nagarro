using System;

namespace iQuest.BigTree.Business
{
    public class JobEndedEventArgs : EventArgs
    {
        public JobResult JobResult { get; }

        public JobEndedEventArgs(JobResult jobResult)
        {
            JobResult = jobResult;
        }
    }
}