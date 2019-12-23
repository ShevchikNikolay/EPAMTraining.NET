using System.Net;


namespace Logging
{
    public struct ReceivedMessage
    {
        public ReceivedMessage(IPEndPoint endPoint, string message)
        {
            EndPoint = endPoint;
            Message = message;
        }

        public IPEndPoint EndPoint { get; set; }
        public string Message { get; set; }
    }
}
