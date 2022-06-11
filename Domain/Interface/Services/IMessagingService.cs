using Domain.Interface.Event;

namespace Domain.Interface.Services
{
    public interface IMessagingService
    {
        void Publish(IEvent @event);
    }
}