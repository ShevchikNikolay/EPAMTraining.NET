using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Network;
using System.Net;


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
