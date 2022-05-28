using CrossCutting.Helpers;
using Domain.Interface;
using Domain.Interface.RabbitMQ;
using Domain.Interface.Repository.RabbitMQ;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Infrastructure.Data.Messaging
{
    public class RabbitMQPublisher : IEventPublisher
    {
        private readonly IConnection connection;
        private readonly IModel channel;

        public RabbitMQPublisher(IRabbitMQUrlProvider provider)
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri(provider.Url),
                UserName = provider.UserName,
                Password = provider.Password
            };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }

        public void Publish(IEvent @event)
        {
            var queName = StringHelper.GetEventName(@event.GetType().Name);

            channel.QueueDeclare(
                queue: queName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var json = JsonConvert.SerializeObject(@event);
            var bytes = Encoding.UTF8.GetBytes(json);

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish(
                exchange: "",
                routingKey: queName,
                basicProperties: properties,
                body: bytes
            );
        }

        public void Dispose()
        {
            channel.Dispose();
            connection.Dispose();
        }
    }
}
