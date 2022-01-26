using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Application.AddStar
{
    public class AddStarRequest: IRequest
    {
        public IStarDetailsProvider StarDetailsProvider { get; set; }
    }
}