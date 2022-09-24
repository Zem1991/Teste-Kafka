using Prova_Prática_Backend_Bari.Kafka;
using Prova_Prática_Backend_Bari.Messaging;

namespace kafka.pubsub.console
{
    class Program
    {
        //static void Main(string[] args)
        static void Main(string[] args)
        {
            string endpoint = "127.0.0.1:9092";
            string topic = "testtopic";
            MessagingSettings messagingSettings = new(endpoint, topic);

            IPublisher publisher = new KafkaPublisher();
            ISubscriber subscriber = new KafkaSubscriber();
            publisher.PublishAsync(messagingSettings);
            subscriber.Subscribe(messagingSettings);

            //ISubscriber subscriber = new KafkaSubscriber();
            //subscriber.Subscribe(messagingSettings);

            //IPublisher publisher = new KafkaPublisher();
            //while (true)
            //{
            //    publisher.PublishAsync(messagingSettings);
            //    await Task.Delay(5000);
            //}

            Console.WriteLine("FIN");
        }
    }
}
