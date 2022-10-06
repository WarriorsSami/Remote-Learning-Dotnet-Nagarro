using System;
using DustInTheWind.ConsoleTools;
using DustInTheWind.ConsoleTools.Spinners;
using iQuest.BigTree.Business;

namespace iQuest.BigTree.Presentation
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

        public void DisplayProblemInfo(int levelCount, int nodeCount)
        {
            CustomConsole.WriteLine();
            CustomConsole.WriteLineEmphasies("This application will generate a binary tree.");
            CustomConsole.WriteLine();
            CustomConsole.WriteLine("Tree levels count: {0:N0}", levelCount);
            CustomConsole.WriteLine("Expected node count: {0:N0}", nodeCount);
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
            CustomConsole.Write("Generated nodes = ");
            CustomConsole.WriteLine(ConsoleColor.DarkYellow, "{0:N0}", jobResult.NodeCount);

            CustomConsole.WriteLine();
            CustomConsole.WriteLine(ConsoleColor.DarkGray, "Elapsed Time = {0}", jobResult.ElapsedTime);
        }

        public void Dispose()
        {
            spinner?.Dispose();
        }
    }
}