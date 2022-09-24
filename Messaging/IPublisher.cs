namespace Prova_Prática_Backend_Bari.Messaging
{
    public interface IPublisher
    {
        Task PublishAsync(MessagingSettings messagingSettings);
    }
}
