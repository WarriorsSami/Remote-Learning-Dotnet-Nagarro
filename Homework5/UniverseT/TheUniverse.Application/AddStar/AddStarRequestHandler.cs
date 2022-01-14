using System;
using System.Collections.Generic;
using iQuest.TheUniverse.Application.GetAllStars;
using iQuest.TheUniverse.Domain;
using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Application.AddStar
{
    public class AddStarRequestHandler : IRequestHandler<StarInfo>
    {
        public Either<Boolean, List<StarInfo>> Execute(IRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            
            var addStarRequest = request as AddStarRequest;
            string starName = addStarRequest?.StarDetailsProvider.GetStarName(); 
            string galaxyName = addStarRequest?.StarDetailsProvider.GetGalaxyName(); 
            return Universe.Instance.AddStar(starName, galaxyName);
        }
    }
}