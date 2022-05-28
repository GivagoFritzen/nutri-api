using System.Threading;

namespace Domain.Interface.Repository.Mongo
{
    public interface IBackgroundQueue
    {
        void Execute(CancellationToken stoppingToken);
    }
}