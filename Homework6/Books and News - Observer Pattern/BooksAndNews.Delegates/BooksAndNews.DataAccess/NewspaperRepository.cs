using System;
using System.Collections.Generic;
using System.IO;
using iQuest.BooksAndNews.Application.DataAccess;
using iQuest.BooksAndNews.Application.Publications;
using Newtonsoft.Json;

namespace iQuest.BooksAndNews.DataAccess
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
