using Domain.Event;
using Infrastructure.Data.Interfaces.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace Infrastructure.Data.Messaging.BackgroundsQueue
{
    public sealed class UserEventQueue : IBackgroundQueue
    {
        private readonly ILogger<IBackgroundQueue> _logger;
        private readonly IMongoDbContext mongoDbContext;

        private readonly IConnection connection;
        private readonly IModel channel;

        public UserEventQueue(
            ILogger<IBackgroundQueue> logger,
            IConfiguration configuration,
            IMongoDbContext mongoDbContext)
        {
            _logger = logger;
            this.mongoDbContext = mongoDbContext;

            var provider = new AppsettingRabbitMQUrlProvider(configuration);
            var factory = new ConnectionFactory()
            {
                Uri = new Uri(provider.Url),
                UserName = provider.UserName,
                Password = provider.Password
            };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }

        public void Execute(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Aguardando mensagens...");

            stoppingToken.ThrowIfCancellationRequested();

            var queName = nameof(UserEvent).Replace("Event", "");
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

                var evento = JsonConvert.DeserializeObject<UserEvent>(message);

                mongoDbContext
                    .GetDatabase(queName)
                    .GetCollection<UserEvent>(queName)
                    .InsertOne(evento);
            };

            channel.BasicConsume(
                queue: queName,
                autoAck: true,
                consumer: consumer
            );
        }
    }
}
