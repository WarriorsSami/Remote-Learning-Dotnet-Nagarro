using System;

namespace VendingMachine.Domain.Presentation.IViews
{
    public interface IDisplayBase
    {
       void DisplayLine(string message, ConsoleColor color);
       void Display(string message, ConsoleColor color); 
       void DisplayError(Exception ex);
       void Pause();
    }
}