using System;
using System.Collections.Generic;
using System.IO;
using BooksAndNews.Domain.DataAccess;
using BooksAndNews.Domain.Publications;
using Newtonsoft.Json;

namespace BooksAndNews.DataAccess
{
    public class NewspaperRepository : INewspaperRepository
    {
        private static readonly List<Newspaper> Newspapers;

        static NewspaperRepository()
        {
            var json = File.ReadAllText("Data\\newspapers.json");
            Newspapers = JsonConvert.DeserializeObject<List<Newspaper>>(json);
        }

        private readonly Random _random;

        public NewspaperRepository()
        {
            _random = new Random();
        }

        public Newspaper GetRandom()
        {
            if (Newspapers.Count == 0)
                return null;

            var index = _random.Next(Newspapers.Count);
            return Newspapers[index];
        }
    }
}
