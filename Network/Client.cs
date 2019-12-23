using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Class describes a client for tcp connections.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Port number to connect.
        /// </summary>
        public const int Port = 13000;

        /// <summary>
        /// Address of server.
        /// </summary>
        public const string Address = "127.0.0.1";

        /// <summary>
        /// Size of incoming buffer.
        /// </summary>
        public const int BufferSize = 256;

        private  TcpClient client;
        private  NetworkStream stream;

        /// <summary>
        /// Delegate accepting any method 'void(string)'.
        /// </summary>
        /// <param name="message">Represents a string.</param>
        public delegate void MessageHandler(string message);

        /// <summary>
        /// Event occures when messagereceived from server.
        /// </summary>
        public event MessageHandler MessageReceived;

        /// <summary>
        /// Initialize an instance of client class.
        /// </summary>
        public Client()
        {
            client = new TcpClient(Address, Port);
            stream = client.GetStream();
            Task.Run(() => ReceivingDataFromServer());
        }

        /// <summary>
        /// The method that running sending data task.
        /// </summary>
        /// <param name="message">Represents a string.</param>
        public void SendMessage(string message)
        {
            Task.Run(() => SendingDataToTheServer(message));
        }

        private async Task ReceivingDataFromServer()
        {
            var buffer = new byte[BufferSize];
            while (true)
            {
                var stringBuilder = new StringBuilder();
                do
                {
                    int packetSize = await stream.ReadAsync(buffer, 0, BufferSize);
                    stringBuilder.Append(Encoding.UTF8.GetString(buffer, 0, packetSize));
                }
                while (stream.DataAvailable);
                MessageReceived?.Invoke(stringBuilder.ToString());
            }
        }
        private async Task SendingDataToTheServer(string message)
        {

            var sendBuffer = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(sendBuffer, 0, sendBuffer.Length);

        }
    }

}
