using System;
using System.Collections.Generic;
using System.IO;
using BooksAndNews.Domain.DataAccess;
using BooksAndNews.Domain.Publications;
using Newtonsoft.Json;

namespace BooksAndNews.DataAccess
{
    public class BookRepository : IBookRepository
    {
        private static readonly List<Book>? Books;

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
