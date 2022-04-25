using System;
using System.Collections.Generic;

namespace iQuest.StarFiles.UniverseModel
{
    internal sealed class Universe: IDisposable
    {
        private readonly List<SimpleStar> _stars = new List<SimpleStar>();

        private bool _disposed;

        public string CreateStarFromTemplate(string name)
        {
            var star = new SimpleStar(name);
            _stars.Add(star);

            Console.WriteLine("Created star {0}", star.Name);
            return star.FileName;
        }

        public Tuple<string, string> CreateBinaryStar(string name)
        {
            var star = new BinaryStar(name);
            _stars.Add(star);

            Console.WriteLine("Created star {0}", star.Name);
            return new Tuple<string, string>(star.FileName, star.AdditionalFilename);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                Console.WriteLine("-----------Disposing Universe-----------");
                if (disposing)
                {
                    _stars.ForEach(s => s.Dispose());
                }

                _disposed = true;
            }            
        }

        ~Universe() => Dispose(false);
    }
}
