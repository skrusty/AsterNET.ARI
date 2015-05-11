using System;
using WebSocket4Net;

namespace AsterNET.ARI.Middleware
{
    public enum ConnectionState
    {
        Open,
        Closed
    }
    public class MessageEventArgs
    {
        public string Message;
    }

    public interface IEventProducer
    {
        WebSocketState State { get; }
        event EventHandler<MessageEventArgs> OnMessageReceived;
        event EventHandler OnConnectionStateChanged;

        void Connect();
        void Disconnect();
    }
}