using Microsoft.AspNetCore.SignalR;
namespace SignalRDemo.Hub
{
    public class MessageHub:Hub<IMessageHubClient>
    {
        // Send a chat message to all connected clients
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.ReceiveMessage(user, message);
        }

        // Send a notification to all connected clients
        public async Task SendNotification(string message)
        {
            await Clients.All.ReceiveNotification(message);
        }
    }
}
