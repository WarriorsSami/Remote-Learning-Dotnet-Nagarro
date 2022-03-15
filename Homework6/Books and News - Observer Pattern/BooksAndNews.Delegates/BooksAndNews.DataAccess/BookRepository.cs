using System;
using System.Collections.Generic;
using System.IO;
using iQuest.BooksAndNews.Application.DataAccess;
using iQuest.BooksAndNews.Application.Publications;
using Newtonsoft.Json;

namespace iQuest.BooksAndNews.DataAccess
{
    public class BookRepository : IBookRepository
    {
        private static readonly List<Book> Books;

        static BookRepository()
        {
            var json = File.ReadAllText("Data\\books.json");
            Books = JsonConvert.DeserializeObject<List<Book>>(json);
        }

        private readonly Random _random;

        public BookRepository()
        {
            _random = new Random();
        }

        public Book GetRandom()
        {
            if (Books.Count == 0)
                return null;

            var index = _random.Next(Books.Count);
            return Books[index];
        }
    }
}
