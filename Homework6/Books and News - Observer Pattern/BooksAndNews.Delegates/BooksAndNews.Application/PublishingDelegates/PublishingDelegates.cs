using iQuest.BooksAndNews.Application.Publications;

namespace iQuest.BooksAndNews.Application.PublishingDelegates
{
    public delegate void HandleBookPublishedDelegate(Book book);
    public delegate void HandleNewsPublishedDelegate(Newspaper news);
}