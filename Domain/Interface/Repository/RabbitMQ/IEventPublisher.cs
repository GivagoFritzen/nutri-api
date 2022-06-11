using Domain.Interface.Event;
using System;

namespace Domain.Interface.Repository.RabbitMQ
{
    public interface IEventPublisher : IDisposable
    {
        void Publish(IEvent @event);
    }
}
