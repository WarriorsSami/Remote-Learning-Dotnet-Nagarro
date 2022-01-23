using System;

namespace VendingMachine.Business.Interfaces.IPresentationLayer
{
    public interface IDisplayBase
    {
       void DisplayLine(string message, ConsoleColor color);
       void Display(string message, ConsoleColor color); 
       void DisplayError(Exception ex);
       void Pause();
    }
}