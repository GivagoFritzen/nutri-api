namespace Domain.Interface.Services
{
    public interface IMessagingService
    {
        void Publish(IEvent @event);
    }
}