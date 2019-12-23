using System.Net;


namespace Logging
{
    /// <summary>
    /// Describes data for log.
    /// </summary>
    public struct ReceivedMessage
    {
        /// <summary>
        /// Inintialize an instance of structure.
        /// </summary>
        /// <param name="endPoint">Represents an IPEndPoint.</param>
        /// <param name="message">Represents a string.</param>
        public ReceivedMessage(IPEndPoint endPoint, string message)
        {
            EndPoint = endPoint;
            Message = message;
        }

        /// <summary>
        /// Network endpoint of a client.
        /// </summary>
        public IPEndPoint EndPoint { get; set; }

        /// <summary>
        /// Message for logging
        /// </summary>
        public string Message { get; set; }
    }
}
