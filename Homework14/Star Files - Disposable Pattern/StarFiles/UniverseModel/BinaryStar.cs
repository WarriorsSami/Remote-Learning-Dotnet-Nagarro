using System;

namespace iQuest.StarFiles.UniverseModel
{
    /// <summary>
    /// A binary star is a star system consisting of two stars orbiting around their common barycenter.
    /// Out BinaryStar instance will create two files (the main one from the base class and an additional one).
    /// </summary>
    internal class BinaryStar : SimpleStar, IDisposable
    {
        private readonly Random _random = new Random();
        private WinApiFile _additionalFile;

        private bool _disposed;

        public string AdditionalFilename => _additionalFile.FileName;

        public BinaryStar(string name) : base(name)
        {
            CreateAndOpenAdditionalFile();
            GenerateAdditionalContent();
        }

        private void CreateAndOpenAdditionalFile()
        {
            var guid = Guid.NewGuid();
            var filePath = $"star-{guid:D}.txt";
            _additionalFile = new WinApiFile(filePath);

            GenerateContentInAdditionalFile();
        }

        private void GenerateContentInAdditionalFile()
        {
            var content = $"This is the star 2 of the binary named '{Name}'" + Environment.NewLine;
            _additionalFile.Write(content);
        }

        protected override void GenerateContent()
        {
            var content =
                $"This is the star 1 of the binary named '{Name}'"
                + Environment.NewLine
                + "This star is made up mostly of Hydrogen and some Helium atoms."
                + Environment.NewLine;

            File.Write(content);
        }

        private void GenerateAdditionalContent()
        {
            for (var i = 0; i < 10; i++)
            {
                var atomicMass = _random.Next(1, 26);
                AddContent(
                    $"Some atoms with atomic mass {atomicMass} have been found in this star."
                        + Environment.NewLine
                );
            }
        }

        private void AddContent(string content)
        {
            var fileIndex = _random.Next(1, 3);

            switch (fileIndex)
            {
                case 1:
                    File.Write(content);
                    break;

                case 2:
                    _additionalFile.Write(content);
                    break;
            }
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _additionalFile.Dispose();
                }

                base.Dispose(disposing);
                _disposed = true;
            }
        }

        ~BinaryStar() => Dispose(false);
    }
}
