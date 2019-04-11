using Microsoft.AspNetCore.Http;
using System;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace WebChat.SocketsManager
{
    public class SocketMiddleware
    {
        private readonly RequestDelegate _next;
        public SocketMiddleware(RequestDelegate next, SocketHandler handler)
        {
            _next = next;
            Handler = handler;
        }
        private SocketHandler Handler { get; set; }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                return;
            }
            var socket = await context.WebSockets.AcceptWebSocketAsync();
            await Receive(WebSocket socket, Action<WebSocketReceiveResult, byte[]> messageToHandle);
        }

        private async Task Receive(WebSocket webSocket, Action<WebSocketReceiveResult, byte[]> messageToHandle)
        {
            throw new NotImplementedException();
        }
    }
}
