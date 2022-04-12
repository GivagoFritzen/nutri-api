using CrossCutting.Helpers;
using Infrastructure.Data.Interfaces.Mongo;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;


namespace Infrastructure.Data.Messaging.BackgroundsQueue.Base
{
    public abstract class BaseQueue<TEvent> : IBackgroundQueue
    {
        protected readonly IModel channel;
        protected readonly IConnection connection;
        protected readonly IMongoCollection<TEvent> mongoCollection;

        protected string queName;

        public BaseQueue(
            IConfiguration configuration,
            IMongoDbContext mongoDbContext)
        {
            var provider = new AppsettingRabbitMQUrlProvider(configuration);
            var factory = new ConnectionFactory()
            {
                Uri = new Uri(provider.Url),
                UserName = provider.UserName,
                Password = provider.Password
            };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();

            queName = StringHelper.GetEventName(typeof(TEvent).Name);
            mongoCollection = mongoDbContext
                    .GetDatabase(queName)
                    .GetCollection<TEvent>(queName);
        }

        public void Execute(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

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

                var evento = JsonConvert.DeserializeObject<TEvent>(message);

                QueueController(evento);
            };

            channel.BasicConsume(
                queue: queName,
                autoAck: true,
                consumer: consumer
            );
        }

        public abstract void QueueController(TEvent evento);
    }
}
