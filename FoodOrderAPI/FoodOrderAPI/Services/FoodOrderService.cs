using Confluent.Kafka;
using FoodOrderAPI.Models;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace FoodOrderAPI.Services
{
    public class FoodOrderService : IFoodOrderService
    {
        private readonly IConfiguration _configuration;

        public FoodOrderService(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        public async Task<string> PublishOrder(Food food)
        {
            ProducerConfig Config = new ProducerConfig
            {
                BootstrapServers = _configuration["BootStrapServer"],

                ClientId = Dns.GetHostName()

            };
            try
            {
                string message=JsonSerializer.Serialize(food);
                string topicName = _configuration["TopicName"];
                using (var producer = new ProducerBuilder
                <Null, string>(Config).Build())
                {
                    var result = await producer.ProduceAsync
                    (topicName, new Message<Null, string>
                    {
                        Value = message
                    });

                    Debug.WriteLine($"Delivery Timestamp:{ result.Timestamp.UtcDateTime}");
                    return await Task.FromResult($"Delivery Timestamp:{ result.Timestamp.UtcDateTime}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }

            return await Task.FromResult("Not Published.....");
        }
    }
}
