using System.Collections.Generic;
using System.Linq;
using iQuest.TheUniverse.Domain;
using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Application.GetAllStars
{
    public abstract class GetAllStarsRequestHandler : IRequestHandler<IEnumerable<StarInfo>>
    {
        public IEnumerable<StarInfo> Execute(IRequest request)
        {
            var starsInfo = new List<StarInfo>();

            var galaxies = Universe.Instance.EnumerateGalaxies();

            foreach (var galaxy in galaxies)
            {
                var stars = galaxy.EnumerateStars();

                starsInfo.AddRange(stars.Select(star => 
                    new StarInfo
                    {
                        GalaxyName = galaxy.Name, 
                        StarName = star
                    })
                );
            }

            return starsInfo;
        }
    }
}