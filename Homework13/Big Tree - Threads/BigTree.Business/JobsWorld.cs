using System;
using iQuest.BigTree.Business.Jobs;

namespace iQuest.BigTree.Business
{
    public class JobsWorld
    {
        private readonly IJob[] jobs =
        {
            new SingleThreadJob(),
            new MultiTaskJob(),
            new MultiThreadJob()
        };

        public int LevelCount { get; } = 14;

        public int ExpectedNodeCount => (int)Math.Pow(2, LevelCount) - 1;

        public event EventHandler Starting;
        public event EventHandler<JobStartingEventArgs> JobStarting;
        public event EventHandler<JobEndedEventArgs> JobEnded;

        public void Run()
        {
            OnStarting();

            foreach (IJob job in jobs)
                RunJob(job);
        }

        private void RunJob(IJob job)
        {
            job.LevelCount = LevelCount;

            JobStartingEventArgs jobStartingEventArgs = new JobStartingEventArgs(job.Description);
            OnJobStarting(jobStartingEventArgs);

            JobResult jobResult = job.Execute();

            JobEndedEventArgs jobEndedEventArgs = new JobEndedEventArgs(jobResult);
            OnJobEnded(jobEndedEventArgs);
        }

        protected virtual void OnStarting()
        {
            Starting?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnJobStarting(JobStartingEventArgs e)
        {
            JobStarting?.Invoke(this, e);
        }

        protected virtual void OnJobEnded(JobEndedEventArgs e)
        {
            JobEnded?.Invoke(this, e);
        }
    }
}