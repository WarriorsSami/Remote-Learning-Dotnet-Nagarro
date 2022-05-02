using System;
using DustInTheWind.ConsoleTools;
using DustInTheWind.ConsoleTools.Spinners;
using iQuest.OneHundred.Business;

namespace iQuest.OneHundred.Presentation
{
    public sealed class JobsView : IDisposable
    {
        private readonly Spinner spinner;

        public JobsView()
        {
            spinner = new Spinner
            {
                MarginTop = 1,
                Label = new InlineTextBlock
                {
                    Text = "Incrementing",
                    ForegroundColor = ConsoleColor.White,
                    MarginRight = 1
                },
                DoneText = new InlineTextBlock("[Done]", ConsoleColor.Green)
            };
        }

        public void StartSpinner()
        {
            spinner.Display();
        }

        public void StopSpinner()
        {
            spinner.Close();
        }

        public void DisplayProblemInfo(uint threadCount, ulong incrementCount)
        {
            CustomConsole.WriteLine();
            CustomConsole.WriteLineEmphasies(
                "This application creates multiple threads that increment the same variable."
            );
            CustomConsole.WriteLine();
            CustomConsole.WriteLine("Thread count: {0:N0}", threadCount);
            CustomConsole.WriteLine("Increment count: {0:N0}", incrementCount);
            CustomConsole.Write("Expected Value: ");
            CustomConsole.WriteLine(
                ConsoleColor.DarkYellow,
                "{0:N0}",
                threadCount * incrementCount
            );
        }

        public void DisplayJobDescription(string title)
        {
            CustomConsole.WriteLine();
            CustomConsole.WriteLineEmphasies(new string('-', 79));
            CustomConsole.WriteLineEmphasies(title);
            CustomConsole.WriteLineEmphasies(new string('-', 79));
        }

        public void DisplayJobResult(JobResult jobResult)
        {
            CustomConsole.Write("Actual Value = ");
            CustomConsole.WriteLine(ConsoleColor.DarkYellow, "{0:N0}", jobResult.Value);

            CustomConsole.WriteLine();
            CustomConsole.WriteLine(
                ConsoleColor.DarkGray,
                "Elapsed Time = {0}",
                jobResult.ElapsedTime
            );
        }

        public void Dispose()
        {
            spinner?.Dispose();
        }
    }
}
