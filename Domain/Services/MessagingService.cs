using Domain.Interface.Event;
using Domain.Interface.Repository.RabbitMQ;
using Domain.Interface.Services;

namespace Domain.Services
{
    public class MessagingService : IMessagingService
    {
        protected IEventPublisher eventPublisher;

        public MessagingService(IEventPublisher eventPublisher)
        {
            this.eventPublisher = eventPublisher;
        }

        public void Publish(IEvent @event)
        {
            eventPublisher.Publish(@event);
        }
    }
}
