using System.Configuration;
using System.Net;

namespace CaesarCipher.DataDecryptor
{
    internal static class DataDecryptorConfiguration
    {

        public static IPAddress IpAddress
        {
            get
            {
                string rawValue = ConfigurationManager.AppSettings["IpAddress"];
                return rawValue == null
                    ? IPAddress.Loopback
                    : IPAddress.Parse(rawValue);
            }
        }

        public static int PortForGenerator
        {
            get
            {
                string rawValue = ConfigurationManager.AppSettings["PortForGenerator"];
                return rawValue == null
                    ? 13001
                    : int.Parse(rawValue);
            }
        }

        public static int PortForReceiver
        {
            get
            {
                string rawValue = ConfigurationManager.AppSettings["PortForReceiver"];
                return rawValue == null
                    ? 13002
                    : int.Parse(rawValue);
            }
        }

        public static int Lag
        {
            get
            {
                string rawValue = ConfigurationManager.AppSettings["Lag"];
                return rawValue == null
                    ? 300
                    : int.Parse(rawValue);
            }
        }
    }
}