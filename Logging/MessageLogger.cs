using Network;
using System.Collections.Generic;


namespace Logging
{
    /// <summary>
    /// Class describes a collection of messages from clients.
    /// </summary>
    public class MessageLogger
    {
        private readonly List<ReceivedMessage> messages;

        /// <summary>
        /// Inintialize an instance of logger.
        /// </summary>
        /// <param name="server">Represents an instance of server.</param>
        public MessageLogger(Server server)
        {
            messages = new List<ReceivedMessage>();
            server.LoggableMessageReceived += (endPoint, message) =>
            {
                messages.Add(new ReceivedMessage(endPoint, message));
            };
        }

    }
}
