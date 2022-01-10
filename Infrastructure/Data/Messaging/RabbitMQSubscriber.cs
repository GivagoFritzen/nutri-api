using Infrastructure.Data.Interfaces.Mongo;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Messaging
{
    public class RabbitMQSubscriber : BackgroundService
    {
        private List<IBackgroundQueue> backgroundsQueue;

        public RabbitMQSubscriber(
            IEnumerable<IBackgroundQueue> backgroundsQueue
        )
        {
            this.backgroundsQueue = backgroundsQueue.ToList();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            for (int i = 0; i < backgroundsQueue.Count; i++)
                backgroundsQueue[i].Execute(stoppingToken);
        }
    }
}
