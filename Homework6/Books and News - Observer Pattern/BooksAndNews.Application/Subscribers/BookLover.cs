using iQuest.BooksAndNews.Application.Publishers;

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
        public BookLover(string name, PrintingOffice printingOffice, ILog log)
        {
        }
    }
}