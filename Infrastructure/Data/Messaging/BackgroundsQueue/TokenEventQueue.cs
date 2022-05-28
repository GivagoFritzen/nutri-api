using Domain.Event;
using Domain.Interface.Repository.Mongo;
using Infrastructure.Data.Messaging.BackgroundsQueue.Base;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Data.Messaging.BackgroundsQueue
{
    public class TokenEventQueue : BaseQueue<TokenEvent>
    {
        public TokenEventQueue(
            IConfiguration configuration,
            IMongoDbContext mongoDbContext) : base(configuration, mongoDbContext)
        {
            CreateExpireAtIndex();
        }

        public override void QueueController(TokenEvent evento)
        {
            if (evento.Delete)
                mongoCollection.DeleteOne(ev => ev.Token == evento.Token);
            else
                mongoCollection.InsertOne(evento);
        }
    }
}
