using Domain.Event;
using Domain.Interface;
using Infrastructure.Data.Interfaces.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private readonly ILogger<RabbitMQSubscriber> _logger;
        private readonly IMongoDbContext mongoDbContext;

        private readonly IConnection connection;
        private readonly IModel channel;

        public RabbitMQSubscriber(
            ILogger<RabbitMQSubscriber> logger,
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

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Aguardando mensagens...");

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

                var evento = JsonConvert.DeserializeObject(message);
                mongoDbContext.GetCollection<IEvent>(nameof(evento)).InsertOne(evento as IEvent);
            };

            channel.BasicConsume(
                queue: queName,
                autoAck: true,
                consumer: consumer
            );

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

        public override void Dispose()
        {
            channel.Dispose();
            connection.Dispose();
        }
    }
}
