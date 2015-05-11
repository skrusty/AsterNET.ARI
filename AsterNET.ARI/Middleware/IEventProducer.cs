using System;
using WebSocket4Net;

namespace AsterNET.ARI.Middleware
{
    public enum ConnectionState
    {
        None = WebSocketState.None,
        Connecting = WebSocketState.Connecting,
        Open = WebSocketState.Open,
        Closing = WebSocketState.Closing,
        Closed = WebSocketState.Closed
    }

    public class MessageEventArgs
    {
        public string Message;
    }

    public interface IEventProducer
    {
        ConnectionState State { get; }
        event EventHandler<MessageEventArgs> OnMessageReceived;
        event EventHandler OnConnectionStateChanged;

        void Connect();
        void Disconnect();
    }
}