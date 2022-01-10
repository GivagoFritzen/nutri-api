using System.Threading;

namespace Infrastructure.Data.Interfaces.Mongo
{
    public interface IBackgroundQueue
    {
        void Execute(CancellationToken stoppingToken);
    }
}