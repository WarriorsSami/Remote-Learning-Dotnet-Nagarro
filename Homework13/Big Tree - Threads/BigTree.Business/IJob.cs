namespace iQuest.BigTree.Business
{
    internal interface IJob
    {
        int LevelCount { get; set; }

        string Description { get; }

        JobResult Execute();
    }
}