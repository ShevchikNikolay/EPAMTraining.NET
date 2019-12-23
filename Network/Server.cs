using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Describes a tcpServer.
    /// </summary>
    public class Server
    {
        /// <summary>
        /// port number for incoming connections.
        /// </summary>
        public const int Port = 13000;

        /// <summary>
        /// Size of incoming buffer.
        /// </summary>
        public const int BufferSize = 256;

        private readonly TcpListener listener;
        private readonly List<TcpClient> clients;
        private bool isRunning;

        /// <summary>
        /// Delegate accepting any method void(string).
        /// </summary>
        /// <param name="message">Represents a string.</param>
        public delegate void MessageHandler(string message);

        /// <summary>
        /// Event occures when client connected.
        /// </summary>
        public event MessageHandler ConnectonAccepted;

        /// <summary>
        /// Event occures when incoming message received.
        /// </summary>
        public event MessageHandler MessageReseived;

        /// <summary>
        /// Delegate accepting any method void (IPEndPoint,string)
        /// </summary>
        /// <param name="endPoint">Represents an IPEndPoint.</param>
        /// <param name="message">Represents a string.</param>
        public delegate void LogHandler(IPEndPoint endPoint, string message);

        /// <summary>
        /// Event occures when message for logging received.
        /// </summary>
        public event LogHandler LoggableMessageReceived;

        /// <summary>
        /// Inintialize an instance of tcpServer.
        /// </summary>
        public Server()
        {
            listener = TcpListener.Create(Port);
            clients = new List<TcpClient>();
            isRunning = false;
        }

        /// <summary>
        /// Method starts the server.
        /// </summary>
        public void Start()
        {
            isRunning = true;
            listener?.Start();
            Task.Run(() => AcceptingClientAsync());
        }

        /// <summary>
        /// Method stops the server.
        /// </summary>
        public void Stop()
        {
            isRunning = false;
            foreach (var item in clients)
            {
                item?.Close();
            }
            listener?.Stop();
        }

        private async Task AcceptingClientAsync()
        {
            while (isRunning)
            {
                var client = await listener.AcceptTcpClientAsync();
                clients.Add(client);
                ConnectonAccepted?.Invoke($"Client {client.Client.RemoteEndPoint.ToString()} has been connected.");
                Task.Run(() => ReadingDataFromClient(client));
            }
        }
        private async Task ReadingDataFromClient(TcpClient client)
        {
            var buffer = new byte[BufferSize];
            var stream = client.GetStream();
            var ipEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
            while (isRunning)
            {
                var stringBuilder = new StringBuilder();
                do
                {
                    int packetSize = await stream.ReadAsync(buffer, 0, BufferSize);
                    stringBuilder.Append(Encoding.UTF8.GetString(buffer, 0, packetSize));
                }
                while (stream.DataAvailable);


                string message = $"{stringBuilder}";
                MessageReseived?.Invoke(clients.Count.ToString());
                LoggableMessageReceived?.Invoke(ipEndPoint, message);
                await Task.Run(() => SendingMessageToClients(message));
            }
            
        }
        private async Task SendingMessageToClients(string message)
        {
            var buffer = Encoding.UTF8.GetBytes(message);
            foreach (var item in clients)
            {
                await item.GetStream().WriteAsync(buffer, 0, buffer.Length);
            }
        }
    }
}
