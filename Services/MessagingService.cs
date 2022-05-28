using Domain.Interface.Services;
using Domain.Interface;
using Infrastructure.Data.Interfaces.RabbitMQ;

namespace Services
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
