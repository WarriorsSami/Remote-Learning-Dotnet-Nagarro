using BooksAndNews.Domain.Publications;

namespace BooksAndNews.Domain.DataAccess
{
    public interface INewspaperRepository
    {
        Newspaper GetRandom();
    }
}
