using BooksAndNews.Domain.Publications;

namespace BooksAndNews.Application.PublishingDelegates
{
    public delegate void HandleBookPublishedDelegate(Book book);
    public delegate void HandleNewsPublishedDelegate(Newspaper news);
}