using System;
using System.Collections.Generic;
using iQuest.TheUniverse.Application.GetAllStars;
using iQuest.TheUniverse.Domain;
using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Application.AddGalaxy
{
    public class AddGalaxyRequestHandler : IRequestHandler<StarInfo>
    {
        public Either<Boolean, List<StarInfo>> Execute(IRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            
            var addGalaxyRequest = request as AddGalaxyRequest; 
            string galaxyName = addGalaxyRequest?.GalaxyDetailsProvider.GetGalaxyName(); 
            return Universe.Instance.AddGalaxy(galaxyName);
        }
    }
}