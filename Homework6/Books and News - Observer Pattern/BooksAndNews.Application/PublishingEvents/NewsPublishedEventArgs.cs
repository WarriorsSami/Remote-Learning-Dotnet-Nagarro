using System;

namespace iQuest.BooksAndNews.Application.PublishingEvents
{
    public class NewsPublishedEventArgs : EventArgs
    {
        public NewsPublishedEventArgs(string newsMessage)
        {
            NewsMessage = newsMessage;
        }

        public string NewsMessage { get; set; }
    }
}
