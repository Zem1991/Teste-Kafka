using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Prova_Prática_Backend_Bari.Messaging;
using System.Text;

namespace Prova_Prática_Backend_Bari.Kafka
{
    public class KafkaSubscriber : ISubscriber
    {
        public void Subscribe(MessagingSettings messagingSettings)
        {
            var consumerConfig = new Dictionary<string, object>
            {
                { "group.id", "myconsumer" },
                { "bootstrap.servers", messagingSettings.Endpoint },
            };

            using (var consumer = new Consumer<Null, string>(consumerConfig, null, new StringDeserializer(Encoding.UTF8)))
            {
                // Subscribe to the OnMessage event
                consumer.OnMessage += (obj, msg) =>
                {
                    Console.WriteLine($"Received: {msg.Value}");
                };

                // Subscribe to the Kafka topic
                consumer.Subscribe(new List<string>() { messagingSettings.Topic });

                // Handle Cancel Keypress 
                var cancelled = false;
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // prevent the process from terminating.
                    cancelled = true;
                };

                Console.WriteLine("Ctrl-C to exit.");

                // Poll for messages
                while (!cancelled)
                {
                    consumer.Poll();
                }
            }
        }
    }
}
