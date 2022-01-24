using System;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.TheUniverse.Domain
{
    public class Universe
    {
        private static Universe _instance;

        public static Universe Instance => _instance ??= new Universe();

        private readonly HashSet<Galaxy> _galaxies = new HashSet<Galaxy>();

        public bool AddGalaxy(string galaxyName)
        {
            if (galaxyName == null) throw new ArgumentNullException(nameof(galaxyName));

            var galaxyExists = _galaxies.Any(x => x.Name == galaxyName);

            if (galaxyExists)
                return false;

            var galaxy = new Galaxy(galaxyName);
            return _galaxies.Add(galaxy);
        }

        public bool AddStar(string starName, string galaxyName)
        {
            var galaxy = _galaxies.FirstOrDefault(x => x.Name == galaxyName);

            if (galaxy == null)
                throw new Exception($"Galaxy '{galaxyName}' does not exist.");

            return galaxy.AddStar(starName);
        }

        public IEnumerable<Galaxy> EnumerateGalaxies()
        {
            return _galaxies;
        }
    }
}