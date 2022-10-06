using System.Windows;
using CaesarCipher.DataDecryptor.Business.ClientLogic;
using CaesarCipher.DataDecryptor.Business.ListenerLogic;
using CaesarCipher.DataDecryptor.Presentation.ViewModels;
using CaesarCipher.DataDecryptor.Presentation.Views;
using ClassLibrary1CaesarCipher.DataDecryptor.DataAccess;

namespace CaesarCipher.DataDecryptor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var quoteRepository = new QuoteRepository();
            
            DataProcessor dataProcessor = new DataProcessor(quoteRepository)
            {
                IpAddress = DataDecryptorConfiguration.IpAddress,
                Port = DataDecryptorConfiguration.PortForGenerator
            };
            
            TcpDataSender dataSender = new TcpDataSender(quoteRepository)
            {
                IpAddress = DataDecryptorConfiguration.IpAddress,
                Port = DataDecryptorConfiguration.PortForReceiver,
                Lag = DataDecryptorConfiguration.Lag
            };

            MainWindow = new DataDecryptorWindow
            {
                DataContext = new DataDecryptorViewModel(dataSender, dataProcessor)
            };

            MainWindow.Show();
        }
    }
}
