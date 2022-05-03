using System;
using iQuest.OneHundred.Business.Jobs;

namespace iQuest.OneHundred.Business
{
    public class JobsWorld
    {
        private readonly IJob[] jobs =
        {
            new UnsafeJob(),
            new LockJob(),
            new MonitorJob(),
            new MutexJob(),
            new SemaphoreJob(),
            new SemaphoreSlimJob(),
            new EventWaitHandleJob()
        };

        public ushort ThreadCount { get; } = 100;

        public ulong IncrementCount { get; } = 1000000;

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
            job.ThreadCount = ThreadCount;
            job.IncrementCount = IncrementCount;

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
