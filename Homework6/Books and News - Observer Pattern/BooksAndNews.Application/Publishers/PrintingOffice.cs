using System;
using iQuest.BooksAndNews.Application.DataAccess;
using iQuest.BooksAndNews.Application.PublishingDelegates;

namespace iQuest.BooksAndNews.Application.Publishers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is the class that will publish books and newspapers.
    /// It must offer a mechanism through which different other classes can subscribe either
    /// to books or to newspaper.
    /// When a book or newspaper is published, the PrintingOffice must notify all the corresponding
    /// subscribers.
    /// </summary>
    public sealed class PrintingOffice
    {
        private readonly IBookRepository _bookRepository;
        private readonly INewspaperRepository _newspaperRepository;
        private readonly ILog _log;

        public HandleBookPublishedDelegate HandleBookPublishedEmitter;
        public HandleNewsPublishedDelegate HandleNewsPublishedEmitter;

        public PrintingOffice(
            IBookRepository bookRepository,
            INewspaperRepository newspaperRepository,
            ILog log
        )
        {
            _bookRepository =
                bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _newspaperRepository =
                newspaperRepository ?? throw new ArgumentNullException(nameof(newspaperRepository));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void PrintRandom(int bookCount, int newspaperCount)
        {
            _log.WriteInfo("Here are some random books:");
            for (var item = 0; item < bookCount; item++)
            {
                var book = _bookRepository.GetRandom();
                _log.WriteInfo($"Printing book {book.Title}");
                HandleBookPublishedEmitter?.Invoke(book);
            }

            _log.WriteInfo("\nHere are some random newspapers:");
            for (var item = 0; item < newspaperCount; item++)
            {
                var newspaper = _newspaperRepository.GetRandom();
                _log.WriteInfo($"Printing newspaper {newspaper.Title}");
                HandleNewsPublishedEmitter?.Invoke(newspaper);
            }
        }
    }
}
