using CrossCuttingTest;
using Domain.Event;
using DomainTest.Event;
using Infrastructure.Data.Interfaces.Mongo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServicesTest
{
    [TestClass]
    public class UserServiceTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetVerificacoesInvalidasData), DynamicDataSourceType.Method)]
        public async Task Verificar_Email_Existe_Guid_Inexistente(List<UserEvent> userEvents)
        {
            var mongoDbContext = new Mock<IMongoDbContext>();
            var mongoDatabase = new Mock<IMongoDatabase>();
            var mongoCollection = new Mock<IMongoCollection<UserEvent>>();

            mongoDbContext.Setup(x => x.GetDatabase(It.IsAny<string>())).Returns(mongoDatabase.Object);
            mongoDatabase.Setup(x => x.GetCollection<UserEvent>(It.IsAny<string>(), It.IsAny<MongoCollectionSettings>())).Returns(mongoCollection.Object);

            mongoCollection.Setup(x => x.FindAsync(
                It.IsAny<FilterDefinition<UserEvent>>(),
                It.IsAny<FindOptions<UserEvent, UserEvent>>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(GetCursorMock(userEvents).Object);

            var userService = new UserService(mongoDbContext.Object);
            Assert.IsFalse(await userService.VerificarEmailExiste("teste@teste.com", Guid.Empty));
        }

        [TestMethod]
        public async Task Verificar_Email_Existe_Guid_Existente_Com_Email_Invalido()
        {
            var mongoFake = new MongoFake<UserEvent>();
            var contextMock = await new MongoDbContextFake<UserEvent>().GetMongoDbContext(mongoFake);
            var userService = new UserService(contextMock.Object);

            Assert.IsTrue(
                await userService.VerificarEmailExiste(
                    "string0@teste.com",
                    Guid.Parse("b2f7a4c1-3ece-4f5a-8327-45b27ebb3e78"))
            );
        }

        [TestMethod]
        public async Task Verificar_Email_Existe_Guid_Existente_Com_Email_Valido()
        {
            var mongoFake = new MongoFake<UserEvent>();
            var contextMock = await new MongoDbContextFake<UserEvent>().GetMongoDbContext(mongoFake);
            var userService = new UserService(contextMock.Object);

            Assert.IsFalse(
                await userService.VerificarEmailExiste(
                    "teste@teste.com",
                    Guid.Parse("b2f7a4c1-3ece-4f5a-8327-45b27ebb3e78"))
            );
        }

        private static IEnumerable<object[]> GetVerificacoesInvalidasData()
        {
            yield return new object[] { new List<UserEvent>() };
            yield return new object[] { new List<UserEvent>() { UserEventFake.GetUserEventEmailFake() } };
        }

        private Mock<IAsyncCursor<UserEvent>> GetCursorMock(List<UserEvent> userEvents)
        {
            var cursor = new Mock<IAsyncCursor<UserEvent>>();
            cursor.Setup(_ => _.Current).Returns(userEvents);
            cursor
                .SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
                .Returns(true)
                .Returns(false);
            cursor
                .SetupSequence(_ => _.MoveNextAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(true))
                .Returns(Task.FromResult(false));

            return cursor;
        }
    }
}
