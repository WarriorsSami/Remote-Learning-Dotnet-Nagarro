using System;
using iQuest.TheUniverse.Domain;
using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Application.AddGalaxy
{
    public abstract class AddGalaxyRequestHandler : IRequestHandler<bool>
    {
        public bool Execute(IRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            
            var addGalaxyRequest = request as AddGalaxyRequest; 
            var galaxyName = addGalaxyRequest?.GalaxyDetailsProvider.GetGalaxyName(); 
            return Universe.Instance.AddGalaxy(galaxyName);
        }
    }
}