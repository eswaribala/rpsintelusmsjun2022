
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CQRSNET6Demo.Events
{
    public class AMQPEventPublisher
    {
        private readonly ConnectionFactory connectionFactory;
        private readonly IConfiguration _configuration;
        public AMQPEventPublisher(IConfiguration configuration)
        {
            connectionFactory = new ConnectionFactory();
            _configuration = configuration;

            connectionFactory.UserName = _configuration["username"];
            connectionFactory.Password = _configuration["password"];
            connectionFactory.VirtualHost = _configuration["hostname"];
            connectionFactory.HostName = _configuration["virtualhost"];
            connectionFactory.Port = AmqpTcpEndpoint.UseDefaultPort;
            //connectionFactory.CreateConnection();
        }
        public void PublishEvent<T>(T @event) where T : IEvent
        {
            using (IConnection conn = connectionFactory.CreateConnection())
            {
                using (IModel channel = conn.CreateModel())
                {
                    var queue = @event is CustomerCreatedEvent ?
                        Constants.QUEUE_CUSTOMER_CREATED : @event is CustomerUpdatedEvent ?
                            Constants.QUEUE_CUSTOMER_UPDATED : Constants.QUEUE_CUSTOMER_DELETED;
                    channel.QueueDeclare(
                        queue: queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );
                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));
                    channel.BasicPublish(
                        exchange: "",
                        routingKey: queue,
                        basicProperties: null,
                        body: body
                    );
                    Debug.WriteLine("HI.....................");
                }
            }
        }
    }
}
