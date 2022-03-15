using BooksAndNews.Domain.Publications;

namespace BooksAndNews.Domain.DataAccess
{
    public interface IBookRepository
    {
        Book GetRandom();
    }
}
