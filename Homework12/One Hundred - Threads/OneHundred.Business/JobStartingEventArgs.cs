using System;

namespace iQuest.OneHundred.Business
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
