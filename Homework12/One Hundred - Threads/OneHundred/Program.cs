using System;
using DustInTheWind.ConsoleTools;
using iQuest.OneHundred.Business;
using iQuest.OneHundred.Presentation;

namespace iQuest.OneHundred
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                ApplicationHeaderControl applicationHeader = new ApplicationHeaderControl();
                applicationHeader.Display();

                JobsWorld jobsWorld = new JobsWorld();

                JobsView jobsView = new JobsView();
                JobsPresenter jobsPresenter = new JobsPresenter(jobsWorld, jobsView);

                jobsWorld.Run();
            }
            catch (Exception ex)
            {
                CustomConsole.WriteLineError(ex.ToString());
            }
            finally
            {
                Pause.QuickDisplay();
            }
        }
    }
}
