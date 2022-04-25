using System;
using System.Collections.Generic;

namespace iQuest.StarFiles.UniverseModel
{
    internal sealed class Universe
    {
        private readonly List<SimpleStar> stars = new List<SimpleStar>();

        public string CreateStarFromTemplate(string name)
        {
            SimpleStar star = new SimpleStar(name);
            stars.Add(star);

            return star.FileName;
        }

        public Tuple<string, string> CreateBinaryStar(string name)
        {
            BinaryStar star = new BinaryStar(name);
            stars.Add(star);

            return new Tuple<string, string>(star.FileName, star.AdditionalFilename);
        }
    }
}