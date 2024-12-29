namespace SignalRDemo.Hub
{
    public interface IMessageHubClient
    {
        Task ReceiveMessage(string user, string message);
        Task ReceiveNotification(string message);
    }
}
