using System;
using BooksAndNews;
using BooksAndNews.Application;
using BooksAndNews.DataAccess;

var log = new Log();
var bookRepository = new BookRepository();
var newspaperRepository = new NewspaperRepository();

// Run
var printingUseCase = new PrintingUseCase(bookRepository, newspaperRepository, log);
printingUseCase.Execute();

// End
Pause();

static void Pause() 
{ 
    Console.WriteLine(); 
    Console.Write("Press any key to continue..."); 
    Console.ReadKey(true); 
    Console.WriteLine();
}
