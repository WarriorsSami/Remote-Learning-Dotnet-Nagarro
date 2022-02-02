using System;
using iQuest.BooksAndNews.Application;
using iQuest.BooksAndNews.DataAccess;

namespace iQuest.BooksAndNews
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Bootstrapping - Application Setup

            var log = new Log();
            var bookRepository = new BookRepository();
            var newspaperRepository = new NewspaperRepository();

            // Run

            var printingUseCase = new PrintingUseCase(bookRepository, newspaperRepository, log);
            printingUseCase.Execute();

            // End

            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
}