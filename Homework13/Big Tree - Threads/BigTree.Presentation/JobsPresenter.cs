using System;
using iQuest.BigTree.Business;

namespace iQuest.BigTree.Presentation
{
    public class JobsPresenter
    {
        private readonly JobsWorld jobsWorld;
        private readonly JobsView jobsView;

        public JobsPresenter(JobsWorld jobsWorld, JobsView jobsView)
        {
            this.jobsWorld = jobsWorld ?? throw new ArgumentNullException(nameof(jobsWorld));
            this.jobsView = jobsView ?? throw new ArgumentNullException(nameof(jobsView));

            jobsWorld.Starting += HandleIncrementUseCaseStarting;
            jobsWorld.JobStarting += HandleJobStarting;
            jobsWorld.JobEnded += HandleJobEnded;
        }

        private void HandleIncrementUseCaseStarting(object? sender, EventArgs e)
        {
            int levelCount = jobsWorld.LevelCount;
            int expectedNodeCount = jobsWorld.ExpectedNodeCount;

            jobsView.DisplayProblemInfo(levelCount, expectedNodeCount);
        }

        private void HandleJobStarting(object? sender, JobStartingEventArgs e)
        {
            jobsView.DisplayJobDescription(e.JobDescription);
            jobsView.StartSpinner();
        }

        private void HandleJobEnded(object? sender, JobEndedEventArgs e)
        {
            jobsView.StopSpinner();
            jobsView.DisplayJobResult(e.JobResult);
        }
    }
}