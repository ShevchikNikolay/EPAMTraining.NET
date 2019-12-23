using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
