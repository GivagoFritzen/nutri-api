using Domain.Interface.Event;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace CrossCuttingTest.Interfaces
{
    public interface IMongoFake<TEvent> where TEvent : IEvent
    {
        void Dispose();
        Task<IMongoCollection<TEvent>> GetCollection();
    }
}