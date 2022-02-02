using System;

namespace iQuest.BooksAndNews.Application.PublishingEvents
{
    public class NewspaperPublishedEventArgs : EventArgs
    {
        public NewspaperPublishedEventArgs(string newspaperMessage)
        {
            NewspaperMessage = newspaperMessage;
        }

        public string NewspaperMessage { get; set; }
    }
}
