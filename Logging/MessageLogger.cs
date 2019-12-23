using Network;
using System.Collections.Generic;


namespace Logging
{
    public class MessageLogger
    {
        private List<ReceivedMessage> messages;

        public MessageLogger(Server server)
        {
            server.LoggableMessageReceived += (endPoint, message) =>
            {
                messages.Add(new ReceivedMessage(endPoint, message));
            };
        }

    }
}
