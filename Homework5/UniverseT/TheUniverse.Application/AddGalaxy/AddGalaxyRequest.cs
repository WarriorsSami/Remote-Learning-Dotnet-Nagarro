using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Application.AddGalaxy
{
    public class AddGalaxyRequest: IRequest
    {
        public IGalaxyDetailsProvider GalaxyDetailsProvider { get; set; }
    }
}