using System;
using System.Windows.Input;
using System.Windows.Threading;
using CaesarCipher.DataDecryptor.Business.ClientLogic;

namespace CaesarCipher.DataDecryptor.Presentation.Commands
{
    public class StartStopCommandForClient : ICommand
    {
        private readonly IDataSender dataSender;
        private readonly Dispatcher callerDispatcher;

        public event EventHandler CanExecuteChanged;

        public StartStopCommandForClient(IDataSender dataSender)
        {
            this.dataSender = dataSender ?? throw new ArgumentNullException(nameof(dataSender));

            callerDispatcher = Dispatcher.CurrentDispatcher;
            dataSender.StateChanged += HandleDataSenderStateChanged;
        }

        private void HandleDataSenderStateChanged(object sender, EventArgs e)
        {
            callerDispatcher.Invoke(OnCanExecuteChanged);
        }

        public bool CanExecute(object parameter)
        {
            DataSenderState dataSenderState = dataSender.State;
            return dataSenderState == DataSenderState.Stopped || dataSenderState == DataSenderState.Running;
        }

        public void Execute(object parameter)
        {
            switch (dataSender.State)
            {
                case DataSenderState.Stopped:
                    dataSender.Start();
                    break;

                case DataSenderState.Running:
                    dataSender.Stop();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
