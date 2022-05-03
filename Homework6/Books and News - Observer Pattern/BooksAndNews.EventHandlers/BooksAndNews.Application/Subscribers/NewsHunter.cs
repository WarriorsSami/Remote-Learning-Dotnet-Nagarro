using BooksAndNews.Application.Publishers;
using BooksAndNews.Application.PublishingEvents;
using BooksAndNews.Domain;
using BooksAndNews.Domain.Publications;

namespace BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever news
    /// are printed.
    ///
    /// Subscribe to the printing office and log each news that was printed.
    /// </summary>
    public class NewsHunter
    {
        private readonly string _name;
        private readonly ILog _log;

        public NewsHunter(string name, PrintingOffice printingOffice, ILog log)
        {
            _name = name;
            _log = log;

            printingOffice.RaiseNewsPublishedEvent += OnNewsPublished;
        }
        
        private void OnNewsPublished(object? sender, NewsPublishedEventArgs e)
        {
            _log.WriteInfo($"{_name} received a newspaper published event: {e.NewsMessage}");
        }
    }
}
