using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class Server
    {
        public const int Port = 13000;
        public const int BufferSize = 256;

        private readonly TcpListener listener;
        private readonly List<TcpClient> clients;
        private bool isRunning;


        public delegate void MessageHandler(string message);
        public event MessageHandler ConnectonAccepted;
        public event MessageHandler MessageReseived;

        public delegate void LogHandler(IPEndPoint endPoint, string message);
        public event LogHandler LoggableMessageReceived;


        public Server()
        {
            listener = TcpListener.Create(Port);
            clients = new List<TcpClient>();
            isRunning = false;
        }

        public Server(int port)
        {
            listener = TcpListener.Create(port);
            clients = new List<TcpClient>();
            isRunning = false;
        }

        public void Start()
        {
            isRunning = true;
            listener?.Start();
            Task.Run(() => AcceptingClientAsync());
        }
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
