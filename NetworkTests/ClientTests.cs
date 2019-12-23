using Microsoft.VisualStudio.TestTools.UnitTesting;
using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Network.Tests
{
    [TestClass()]
    public class ClientTests
    {
        [TestMethod()]
        public void SendingMessageTest()
        {
            //arrange
            var server = new Server();
            server.Start();
            
            var client = new Client();
            var actual = "";
            var expected = "Тестовое сообщение.";
            //server.MessageReseived += (message) => { actual = message; };
            client.MessageReceived += (message) => { actual = message; };



            //action
            client.SendMessage(expected);
            //actual = client.Message;
            //asert
            Assert.AreEqual(expected, actual);
        }
    }
}