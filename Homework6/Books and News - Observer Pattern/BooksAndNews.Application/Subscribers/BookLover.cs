using iQuest.BooksAndNews.Application.Publishers;
using iQuest.BooksAndNews.Application.PublishingEvents;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever a book
    /// is printed.
    ///
    /// Subscribe to the printing office and log each book that was printed.
    /// </summary>
    public class BookLover
    {
        private readonly string _name;
        private readonly ILog _log;

        public BookLover(string name, PrintingOffice printingOffice, ILog log)
        {
            _name = name;
            _log = log;

            printingOffice.RaiseBookPublishedEvent += OnBookPublished;
        }

        private void OnBookPublished(object sender, BookPublishedEventArgs e)
        {
            _log.WriteInfo($"{_name} received a book published event: {e.BookMessage}");
        }
    }
}
