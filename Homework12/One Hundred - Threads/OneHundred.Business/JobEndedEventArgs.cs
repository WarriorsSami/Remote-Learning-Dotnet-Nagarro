using System;

namespace iQuest.OneHundred.Business
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
