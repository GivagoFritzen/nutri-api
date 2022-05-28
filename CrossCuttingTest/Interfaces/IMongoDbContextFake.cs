using Domain.Interface;
using Domain.Interface.Repository.Mongo;
using Moq;
using System.Threading.Tasks;

namespace CrossCuttingTest.Interfaces
{
    public interface IMongoDbContextFake<TEvent> where TEvent : IEvent
    {
        Task<Mock<IMongoDbContext>> GetMongoDbContext(MongoFake<TEvent> mongoFake);
    }
}