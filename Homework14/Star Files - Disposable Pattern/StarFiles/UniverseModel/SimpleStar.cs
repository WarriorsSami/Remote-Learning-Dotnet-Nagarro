﻿using System;

namespace iQuest.StarFiles.UniverseModel
{
    /// <summary>
    /// Will generate a file on disk.
    /// </summary>
    internal class SimpleStar : IDisposable
    {
        protected WinApiFile File { get; private set; }

        private bool _disposed;

        public string Name { get; }

        public string FileName => File.FileName;

        public SimpleStar(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));

            CreateAndOpenFile();
        }

        private void CreateAndOpenFile()
        {
            var guid = Guid.NewGuid();
            var filePath = $"star-{guid:D}.txt";
            File = new WinApiFile(filePath);

            GenerateContent();
        }

        protected virtual void GenerateContent()
        {
            var content =
                $"This is the simple star named '{Name}'"
                + Environment.NewLine
                + "This star is made up mostly of Hydrogen and some Helium atoms."
                + Environment.NewLine;

            File.Write(content);
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    File.Dispose();
                }

                _disposed = true;
            }
        }

        ~SimpleStar() => Dispose(false);
    }
}
