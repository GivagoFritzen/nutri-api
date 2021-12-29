using Domain.Interface;
using System;

namespace Infrastructure.Data.Interfaces.RabbitMQ
{
    public interface IEventPublisher : IDisposable
    {
        void Publish(IEvent @event);
    }
}
