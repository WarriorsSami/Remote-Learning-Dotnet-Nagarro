using System;
using iQuest.TheUniverse.Domain;
using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Application.AddStar
{
    public abstract class AddStarRequestHandler : IRequestHandler<bool>
    {
        public bool Execute(IRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            
            var addStarRequest = request as AddStarRequest;
            var starName = addStarRequest?.StarDetailsProvider.GetStarName(); 
            var galaxyName = addStarRequest?.StarDetailsProvider.GetGalaxyName(); 
            return Universe.Instance.AddStar(starName, galaxyName);
        }
    }
}