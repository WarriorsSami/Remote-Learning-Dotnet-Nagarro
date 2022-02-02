using System;
using System.Collections.Generic;
using iQuest.BooksAndNews.Application.DataAccess;
using iQuest.BooksAndNews.Application.Publishers;
using iQuest.BooksAndNews.Application.Subscribers;

namespace iQuest.BooksAndNews.Application
{
    public class PrintingUseCase
    {
        private readonly IBookRepository _bookRepository;
        private readonly INewspaperRepository _newspaperRepository;
        private readonly ILog _log;

        private PrintingOffice _printingOffice;
        private readonly List<BookLover> _bookLovers = new List<BookLover>();
        private readonly List<NewsHunter> _newsHunters = new List<NewsHunter>();

        public PrintingUseCase(
            IBookRepository bookRepository,
            INewspaperRepository newspaperRepository,
            ILog log
        )
        {
            _bookRepository =
                bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _newspaperRepository =
                newspaperRepository ?? throw new ArgumentNullException(nameof(newspaperRepository));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void Execute()
        {
            CreatePrintingOffice();
            CreateBookLovers();
            CreateNewsHunters();

            _printingOffice.PrintRandom(2, 5);
        }

        private void CreatePrintingOffice()
        {
            _printingOffice = new PrintingOffice(_bookRepository, _newspaperRepository, _log);
        }

        private void CreateBookLovers()
        {
            var william = new BookLover("William", _printingOffice, _log);
            _bookLovers.Add(william);

            var james = new BookLover("James", _printingOffice, _log);
            _bookLovers.Add(james);

            var anna = new BookLover("Anna", _printingOffice, _log);
            _bookLovers.Add(anna);
        }

        private void CreateNewsHunters()
        {
            var alice = new NewsHunter("Alice", _printingOffice, _log);
            _newsHunters.Add(alice);

            var johnny = new NewsHunter("Johnny", _printingOffice, _log);
            _newsHunters.Add(johnny);
        }
    }
}
