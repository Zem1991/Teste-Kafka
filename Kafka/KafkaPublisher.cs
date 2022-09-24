using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Prova_Prática_Backend_Bari.Hello_World;
using Prova_Prática_Backend_Bari.Messaging;
using System.Text;

namespace Prova_Prática_Backend_Bari.Kafka
{
    public class KafkaPublisher : IPublisher
    {
        public async Task PublishAsync(MessagingSettings messagingSettings)
        {
            var producerConfig = new Dictionary<string, object> { { "bootstrap.servers", messagingSettings.Endpoint } };

            using (var producer = new Producer<Null, string>(producerConfig, null, new StringSerializer(Encoding.UTF8)))
            {
                while (true)
                {
                    //for (int i = 0; i < 10; i++)
                    {
                        HelloWorldMessage helloWorldMessage = new();
                        string message = helloWorldMessage.ToString();
                        var result = producer.ProduceAsync(messagingSettings.Topic, null, message).GetAwaiter().GetResult();

                        //Console.WriteLine($"Event {i} sent on Partition: {result.Partition} with Offset: {result.Offset}");
                        Console.WriteLine($"Event sent on Partition: {result.Partition} with Offset: {result.Offset}");
                    }
                    await Task.Delay(5000);
                }
            }
        }
    }
}
