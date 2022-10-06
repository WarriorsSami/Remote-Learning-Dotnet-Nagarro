namespace iQuest.OneHundred.Business
{
    internal interface IJob
    {
        ushort ThreadCount { get; set; }

        ulong IncrementCount { get; set; }

        string Description { get; }

        JobResult Execute();
    }
}
