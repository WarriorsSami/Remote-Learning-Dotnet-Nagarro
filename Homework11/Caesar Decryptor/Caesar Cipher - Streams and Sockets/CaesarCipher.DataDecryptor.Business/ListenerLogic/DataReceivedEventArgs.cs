using System;

namespace CaesarCipher.DataDecryptor.Business.ListenerLogic
{
    public class DataReceivedEventArgs : EventArgs
    {
        public string Data { get; }

        public DataReceivedEventArgs(string data)
        {
            Data = data;
        }
    }
}