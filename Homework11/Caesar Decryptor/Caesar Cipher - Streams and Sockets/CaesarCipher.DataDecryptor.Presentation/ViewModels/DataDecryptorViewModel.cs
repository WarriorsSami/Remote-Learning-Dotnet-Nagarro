using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net;
using CaesarCipher.DataDecryptor.Business.ClientLogic;
using CaesarCipher.DataDecryptor.Business.ListenerLogic;
using CaesarCipher.DataDecryptor.Presentation.Commands;
using iQuest.CaesarCipher.PresentationBase.Controls;
using iQuest.CaesarCipher.PresentationBase.ViewModels;

namespace CaesarCipher.DataDecryptor.Presentation.ViewModels
{
    public class DataDecryptorViewModel : ViewModelBase
    {
        private readonly IDataSender dataSender;
        private string startButtonTextForClient;
        private string errorMessageForClient;
        private bool areDataInputFieldsEnabledForClient;
        private long bytesSentCount;
        private LedState ledStateForClient;

        public IPAddress IpAddressForClient
        {
            get => dataSender.IpAddress;
            set
            {
                dataSender.IpAddress = value;
                OnPropertyChanged();
            }
        }

        public int PortForClient
        {
            get => dataSender.Port;
            set
            {
                dataSender.Port = value;
                OnPropertyChanged();
            }
        }

        public int Lag
        {
            get => dataSender.Lag;
            set
            {
                dataSender.Lag = value;
                OnPropertyChanged();
            }
        }

        public bool AreDataInputFieldsEnabledForClient
        {
            get => areDataInputFieldsEnabledForClient;
            set
            {
                areDataInputFieldsEnabledForClient = value;
                OnPropertyChanged();
            }
        }

        public string StartButtonTextForClient
        {
            get => startButtonTextForClient;
            private set
            {
                startButtonTextForClient = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessageForClient
        {
            get => errorMessageForClient;
            set
            {
                errorMessageForClient = value;
                OnPropertyChanged();
            }
        }

        public long BytesSentCount
        {
            get => bytesSentCount;
            private set
            {
                bytesSentCount = value;
                OnPropertyChanged();
            }
        }

        public LedState LedStateForClient
        {
            get => ledStateForClient;
            private set
            {
                ledStateForClient = value;
                OnPropertyChanged();
            }
        }

        private readonly DataProcessor dataProcessor;
        private string startButtonTextForListener;
        private string errorMessageForListener;
        private bool areDataInputFieldsEnabledForListener;
        private string receivedText;
        private readonly ConcurrentQueue<string> receivedData = new ConcurrentQueue<string>();
        private long receivedBytesCount;
        private LedState ledStateForListener;

        public IPAddress IpAddressForListener
        {
            get => dataProcessor.IpAddress;
            set
            {
                dataProcessor.IpAddress = value;
                OnPropertyChanged();
            }
        }

        public int PortForListener
        {
            get => dataProcessor.Port;
            set
            {
                dataProcessor.Port = value;
                OnPropertyChanged();
            }
        }

        public bool AreDataInputFieldsEnabledForListener
        {
            get => areDataInputFieldsEnabledForListener;
            set
            {
                areDataInputFieldsEnabledForListener = value;
                OnPropertyChanged();
            }
        }

        public string StartButtonTextForListener
        {
            get => startButtonTextForListener;
            private set
            {
                startButtonTextForListener = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessageForListener
        {
            get => errorMessageForListener;
            set
            {
                errorMessageForListener = value;
                OnPropertyChanged();
            }
        }

        public string ReceivedText
        {
            get => receivedText;
            set
            {
                receivedText = value;
                OnPropertyChanged();
            }
        }

        public long ReceivedBytesCount
        {
            get => receivedBytesCount;
            private set
            {
                receivedBytesCount = value;
                OnPropertyChanged();
            }
        }

        public LedState LedStateForListener
        {
            get => ledStateForListener;
            private set
            {
                ledStateForListener = value;
                OnPropertyChanged();
            }
        }

        public StartStopCommandForClient StartStopCommandForClient { get; }
        public StartStopCommandForListener StartStopCommandForListener { get; }

        public DataDecryptorViewModel(
            IDataSender dataSender,
            DataProcessor dataProcessor
        )
        {
            this.dataSender = dataSender;
            this.dataProcessor = dataProcessor;

            dataSender.StateChanged += HandleDataSenderStateChangedForClient;
            dataSender.Error += HandleDataSenderErrorForClient;
            dataSender.BytesSentCountChanged += HandleBytesSentCountChangedForClient;
            
            dataProcessor.StateChanged += HandleDataSenderStateChangedForListener;
            dataProcessor.Error += HandleDataSenderErrorForListener;
            dataProcessor.DataReceived += HandleDataReceived;
            dataProcessor.ReceivedCharsChanged += HandleReceivedCharsChanged;

            StartStopCommandForClient = new StartStopCommandForClient(dataSender);
            StartStopCommandForListener = new StartStopCommandForListener(dataProcessor);
            
            BytesSentCount = 0;

            UpdateLedStateForClient();
            UpdateButtonStateForClient();
            
            UpdateLedStateForListener();
            UpdateButtonStateForListener();
        }

        private void HandleBytesSentCountChangedForClient(object sender, EventArgs e)
        {
            BytesSentCount = dataSender.BytesSentCount;
        }

        private void HandleDataSenderErrorForClient(object sender, ErrorEventArgs e)
        {
            Exception exception = e.GetException();
            ErrorMessageForClient = exception?.Message;
        }

        private void HandleDataSenderStateChangedForClient(object sender, EventArgs e)
        {
            if (dataSender.State == DataSenderState.Starting)
                ErrorMessageForClient = null;

            UpdateLedStateForClient();
            UpdateButtonStateForClient();
        }

        private void UpdateLedStateForClient()
        {
            switch (dataSender.State)
            {
                case DataSenderState.Stopped:
                case DataSenderState.Starting:
                case DataSenderState.Stopping:
                    LedStateForClient = LedState.Off;
                    break;

                case DataSenderState.Running:
                    LedStateForClient = LedState.On;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateButtonStateForClient()
        {
            DataSenderState dataSenderState = dataSender.State;

            AreDataInputFieldsEnabledForClient = dataSenderState == DataSenderState.Stopped;

            switch (dataSenderState)
            {
                case DataSenderState.Stopped:
                case DataSenderState.Starting:
                    StartButtonTextForClient = "Start";
                    break;

                case DataSenderState.Running:
                case DataSenderState.Stopping:
                    StartButtonTextForClient = "Stop";
                    break;

                default:
                    StartButtonTextForClient = string.Empty;
                    break;
            }
        }
        
        private void HandleReceivedCharsChanged(object sender, EventArgs e)
        {
            ReceivedBytesCount = dataProcessor.ReceivedBytesCount;
        }

        private void HandleDataSenderErrorForListener(object sender, ErrorEventArgs e)
        {
            Exception exception = e.GetException();
            ErrorMessageForListener = exception?.Message;
        }

        private void HandleDataSenderStateChangedForListener(object sender, EventArgs e)
        {
            if (dataProcessor.State == DataProcessorState.Starting)
                ErrorMessageForListener = null;

            UpdateLedStateForListener();
            UpdateButtonStateForListener();
        }

        private void UpdateLedStateForListener()
        {
            switch (dataProcessor.State)
            {
                case DataProcessorState.Stopped:
                case DataProcessorState.Starting:
                case DataProcessorState.Stopping:
                    LedStateForListener = LedState.Off;
                    break;
                
                case DataProcessorState.Running:
                    LedStateForListener = LedState.On;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateButtonStateForListener()
        {
            DataProcessorState dataProcessorState = dataProcessor.State;

            AreDataInputFieldsEnabledForListener = dataProcessorState == DataProcessorState.Stopped;

            switch (dataProcessorState)
            {
                case DataProcessorState.Stopped:
                case DataProcessorState.Starting:
                    StartButtonTextForListener = "Start";
                    break;

                case DataProcessorState.Running:
                case DataProcessorState.Stopping:
                    StartButtonTextForListener = "Stop";
                    break;

                default:
                    StartButtonTextForListener = string.Empty;
                    break;
            }
        }

        private void HandleDataReceived(object sender, DataReceivedEventArgs e)
        {
            receivedData.Enqueue(e.Data);

            if (receivedData.Count > 50)
                receivedData.TryDequeue(out _);

            ReceivedText = string.Join(Environment.NewLine, receivedData.Reverse());
        }
    }
}
