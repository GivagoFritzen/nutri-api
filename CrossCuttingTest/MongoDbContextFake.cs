using CrossCuttingTest.Interfaces;
using Domain.Interface.Event;
using Domain.Interface.Repository.Mongo;
using Moq;
using System.Threading.Tasks;

namespace CrossCuttingTest
{
    public class MongoDbContextFake<TEvent> : IMongoDbContextFake<TEvent> where TEvent : IEvent
    {
        public async Task<Mock<IMongoDbContext>> GetMongoDbContext(MongoFake<TEvent> mongoFake)
        {
            var contextMock = new Mock<IMongoDbContext>();
            contextMock.Setup(x => x.GetDatabase()).Returns(mongoFake.GetDatabase());
            contextMock.Setup(x => x.GetCollection<TEvent>(It.IsAny<string>())).Returns(await mongoFake.GetCollection());

            return contextMock;
        }
    }
}
