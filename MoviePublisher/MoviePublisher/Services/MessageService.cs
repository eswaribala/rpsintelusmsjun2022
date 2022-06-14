﻿using Confluent.Kafka;
using System.Diagnostics;
using System.Net;

namespace MoviePublisher.Services
{
    public class MessageService:IMessageService
    {
        public async Task<string> PublishMovie(string topicName, string message, IConfiguration configuration)
        {
            ProducerConfig Config = new ProducerConfig
            {
                BootstrapServers = configuration["BootStrapServer"],

                ClientId = Dns.GetHostName()

            };
            try
            {
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
