namespace Prova_Prática_Backend_Bari.Messaging
{
    public class MessagingSettings
    {
        public string Endpoint { get; private set; }
        public string Topic { get; private set; }

        public MessagingSettings(string endpoint, string topic)
        {
            Endpoint = endpoint;
            Topic = topic;
        }
    }
}
