using System;

namespace iQuest.BigTree.Business
{
    public class JobStartingEventArgs : EventArgs
    {
        public string JobDescription { get; }

        public JobStartingEventArgs(string jobDescription)
        {
            JobDescription = jobDescription;
        }
    }
}