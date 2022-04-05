using System;
using System.Windows.Input;
using System.Windows.Threading;
using CaesarCipher.DataDecryptor.Business.ListenerLogic;

namespace CaesarCipher.DataDecryptor.Presentation.Commands
{
    public class StartStopCommandForListener : ICommand
    {
        private readonly DataProcessor dataProcessor;
        private readonly Dispatcher callerDispatcher;

        public event EventHandler CanExecuteChanged;

        public StartStopCommandForListener(DataProcessor dataProcessor)
        {
            this.dataProcessor = dataProcessor ?? throw new ArgumentNullException(nameof(dataProcessor));

            callerDispatcher = Dispatcher.CurrentDispatcher;
            dataProcessor.StateChanged += HandleDataSenderStateChanged;
        }

        private void HandleDataSenderStateChanged(object sender, EventArgs e)
        {
            callerDispatcher.Invoke(OnCanExecuteChanged);
        }

        public bool CanExecute(object parameter)
        {
            DataProcessorState dataSenderState = dataProcessor.State;
            return dataSenderState == DataProcessorState.Stopped || dataSenderState == DataProcessorState.Running;
        }

        public void Execute(object parameter)
        {
            switch (dataProcessor.State)
            {
                case DataProcessorState.Stopped:
                    dataProcessor.Start();
                    break;

                case DataProcessorState.Running:
                    dataProcessor.RequestStop();
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
