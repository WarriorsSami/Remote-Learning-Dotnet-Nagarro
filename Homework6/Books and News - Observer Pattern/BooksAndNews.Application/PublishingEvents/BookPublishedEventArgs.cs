﻿using System;

namespace iQuest.BooksAndNews.Application.PublishingEvents
{
    public class BookPublishedEventArgs : EventArgs
    {
        public BookPublishedEventArgs(string bookMessage)
        {
            BookMessage = bookMessage;
        }

        public string BookMessage { get; set; }
    }
}
