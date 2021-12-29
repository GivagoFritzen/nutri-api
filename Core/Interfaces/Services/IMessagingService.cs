using Domain.Interface;

namespace Core.Interfaces.Services
{
    public interface IMessagingService
    {
        void Publish(IEvent @event);
    }
}