using Infrastructure.Data.Interfaces.RabbitMQ;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Messaging
{
    public class RabbitMQSubscriber : BackgroundService
    {
        private readonly IConnection connection;
        private readonly IModel channel;

        public RabbitMQSubscriber(IRabbitMQUrlProvider provider)
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

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var queName = "teste";
            channel.QueueDeclare(
                queue: queName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray(); ;
                var message = Encoding.UTF8.GetString(body);
            };

            channel.BasicConsume(
                queue: queName,
                autoAck: true,
                consumer: consumer
            );

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            channel.Dispose();
            connection.Dispose();
        }
    }
}
