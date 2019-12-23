using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class Client
    {
        public const int Port = 13000;
        public const string Address = "127.0.0.1";
        public const int BufferSize = 256;

        private TcpClient client;
        private NetworkStream stream;
        private string userName;

        public delegate void MessageHandler(string message);
        public event MessageHandler MessageReceived;

        public Client(string name)
        {
            client = new TcpClient(Address, Port);
            stream = client.GetStream();
            userName = name;
            Task.Run(() => ReceivingDataFromServer());
        }
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
                Console.WriteLine(stringBuilder);
            }
        }
        private async Task SendingDataToTheServer(string message)
        {

            var sendBuffer = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(sendBuffer, 0, sendBuffer.Length);

        }
    }

}
